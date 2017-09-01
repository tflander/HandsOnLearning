package banking.service;

import banking.email.EmailService;
import banking.model.User;
import banking.persistence.Repository;

import java.util.UUID;

public class CustomerService {

  private Repository<User> userRepository;
  private EmailService emailService;

  public CustomerService(Repository<User> userRepository, EmailService emailService) {
    this.userRepository = userRepository;
    this.emailService = emailService;
  }

  public void updateEmailAddress(UUID userId, String emailAddress) {
    User user = userRepository.findOne(userId).orElseThrow(() -> new RuntimeException("Invalid userId"));
    User updatedUser = user.cloneWithEmailAddress(emailAddress);
    userRepository.save(updatedUser);
  }

  public UUID sendFraudAlert(UUID userId) {
    // TODO implement this method!
    return null;
  }

}
