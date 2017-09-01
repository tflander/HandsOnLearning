package banking;

import banking.model.Account;
import banking.model.Money;
import banking.persistence.FileRepository;
import banking.service.AccountService;
import com.google.gson.Gson;
import spark.Service;

import java.io.File;
import java.util.UUID;

public class RestApi {

  private static final int PORT = 8080;

  private AccountService accountService;

  public static void main(String[] strings) {
    FileRepository<Account> repository = new FileRepository<>(Account.class, new File("accounts.json"));
    AccountService service = new AccountService(repository);
    new RestApi(service).run(Service.ignite());
  }

  public RestApi(AccountService accountService) {
    this.accountService = accountService;
  }

  public void run(Service spark) {
    spark.port(PORT);

    spark.post("/accounts", (request, response) -> {
      Money startingBalance = new Gson().fromJson(request.body(), Money.class);
      return accountService.openNewAccount(startingBalance);
    }, new Gson()::toJson);

    
    spark.get("/accounts/:id", (request, response) -> {
      UUID id = UUID.fromString(request.params("id"));
      return accountService.findAccount(id);
    }, new Gson()::toJson);


    spark.after((request, response) -> {
      response.type("application/json");
    });
  }

}
