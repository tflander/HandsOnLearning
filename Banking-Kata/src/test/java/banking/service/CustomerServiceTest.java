package banking.service;

import static org.assertj.core.api.Assertions.assertThat;
import static org.assertj.core.api.Assertions.assertThatThrownBy;

import banking.email.EmailService;
import banking.model.User;
import banking.persistence.NetworkRepository;
import banking.persistence.Repository;
import org.junit.Before;
import org.junit.Ignore;
import org.junit.Test;

import java.util.Optional;
import java.util.UUID;

public class CustomerServiceTest {

  private Repository<User> userRepository;
  private CustomerService customerService;
  private User user;
  private UUID userId;

  @Before
  public void setup() {
    user = new User("email@example.com");
    userId = user.getId();
    userRepository = new NetworkRepository<User>();
    userRepository.save(user);
    customerService = new CustomerService(userRepository, mockEmailService);
  }

  @Test
  public void updateEmailSavesTheNewAddress() throws Exception {
    String expectedEmailAddress = "my-new-email@example.com";

    customerService.updateEmailAddress(userId, expectedEmailAddress);
    Optional<User> updatedUser = userRepository.findOne(userId);

    assertThat(updatedUser.get().getEmailAddress()).isEqualTo(expectedEmailAddress);
  }

  @Test
  public void updateEmailThrowsAnErrorForInvalidUserId() throws Exception {
    UUID invalidUserId = UUID.randomUUID();

    assertThatThrownBy(() -> {
      customerService.updateEmailAddress(invalidUserId, "my-new-email@example.com");
    }).hasMessage("Invalid userId");
  }

  @Test
  public void updateEmailSavesACopyOfTheUserWithoutModifyingTheOriginal() throws Exception {
    String expectedEmailAddress = "my-new-email@example.com";

    customerService.updateEmailAddress(userId, expectedEmailAddress);

    assertThat(user.getEmailAddress()).isNotEqualTo("my-new-email@example.com");
  }

  
  
  
  private UUID expectedConfirmationCode = UUID.randomUUID();
  private EmailService mockEmailService = new EmailService() {

    @Override
    public UUID sendMessage(String emailAddress, String message) {
      // Whatever fake implementation you choose...
      return null;
    }
  };
  
  @Test
  @Ignore("Implement this test!")
  public void sendFraudAlertWillNotifyTheUserByEmail() throws Exception {
    UUID confirmationCode = customerService.sendFraudAlert(userId);

    assertThat(confirmationCode).isEqualTo(expectedConfirmationCode);
  }

  @Test
  @Ignore("Implement this test!")
  public void sendFraudAlertWillThrowAnErrorIfUserIdIsNotFound() throws Exception {
    // TODO
  }

}
