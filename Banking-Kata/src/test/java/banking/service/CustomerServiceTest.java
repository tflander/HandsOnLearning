package banking.service;

import static org.assertj.core.api.Assertions.assertThat;
import static org.assertj.core.api.Assertions.assertThatThrownBy;

import banking.model.User;
import banking.persistence.NetworkRepository;
import banking.persistence.Repository;
import org.junit.Before;
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
    user = new User("original-email@example.com");
    userId = user.getId();
    userRepository = new NetworkRepository<User>();
    userRepository.save(user);
    customerService = new CustomerService(userRepository);
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

}
