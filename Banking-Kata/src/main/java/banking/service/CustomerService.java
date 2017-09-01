package banking.service;

import banking.model.User;
import banking.persistence.Repository;

import java.util.UUID;

public class CustomerService {

  private Repository<User> userRepository;

  public CustomerService(Repository<User> userRepository) {
    this.userRepository = userRepository;
  }

  public void updateEmailAddress(UUID userId, String emailAddress) {
    User user = userRepository.findOne(userId).orElseThrow(() -> new RuntimeException("Invalid userId"));
    User updatedUser = user.cloneWithEmailAddress(emailAddress);
    userRepository.save(updatedUser);
  }

}
