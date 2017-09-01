package banking;

import static helpers.CustomMatchers.closeToFloat;
import static io.restassured.RestAssured.given;
import static org.assertj.core.api.Assertions.assertThat;
import static org.hamcrest.core.Is.is;

import banking.model.Account;
import banking.model.Money;
import banking.persistence.FakeRepository;
import banking.service.AccountService;
import com.google.gson.Gson;
import io.restassured.http.ContentType;
import io.restassured.response.ValidatableResponse;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import spark.Service;

public class RestApiTest {

  private static final double ONE_CENT = 0.01;
  private static final String ACCOUNT_BALANCE = "12.34";

  private FakeRepository<Account> accountRepository;
  private AccountService accountService;
  private Account account;
  private Service spark;

  @Before
  public void setup() {
    setupAccounts();
    startServer();
  }

  private void setupAccounts() {
    account = new Account(Money.of(ACCOUNT_BALANCE));

    accountRepository = new FakeRepository<>();
    accountRepository.save(account);
    accountService = new AccountService(accountRepository);
  }

  public void startServer() {
    spark = Service.ignite();
    new RestApi(accountService).run(spark);
    spark.awaitInitialization();
  }

  @After
  public void stopServer() {
    spark.stop();
  }

  @Test
  public void shouldGetTheCorrectAccountBalance() throws Exception {

    given()
        .accept(ContentType.JSON)
        .pathParam("accountId", account.getId().toString())

    .when()
        .get("/accounts/{accountId}")

    .then()
        .statusCode(200)
        .body(
            "balance.amount", closeToFloat(12.34, ONE_CENT),
            "balance.currency", is("USD"));
  }
  
  @Test
  public void canCreateAnAccountByPostingToAccountsEndpoint() throws Exception {
    Money startingBalance = Money.of("67.98");
    accountRepository.clear();
    
    ValidatableResponse responseValidator = given()
      .contentType(ContentType.JSON)
      .body(new Gson().toJson(startingBalance))

  .when()
      .post("/accounts")
  
  .then()
      .statusCode(200);
    
    assertThat(accountRepository.items).hasSize(1);
    Account savedAccount = accountRepository.allItems().get(0);
    assertThat(savedAccount.getBalance()).isEqualTo(startingBalance);
    
    responseValidator.body("id", is(savedAccount.getId().toString()));
  }

}
