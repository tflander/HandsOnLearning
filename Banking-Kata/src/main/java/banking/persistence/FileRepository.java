package banking.persistence;

import banking.model.Identifiable;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

public class FileRepository<T extends Identifiable> implements Repository<T> {

  private File file;

  public FileRepository(File file) {
    this.file = file;
  }

  @Override
  public Optional<T> findOne(UUID id) {
    try (FileReader reader = new FileReader(file)) {
      
      Type type = new TypeToken<ArrayList<T>>(){}.getType();
      
      List<T> allItems = new Gson().fromJson(reader, type);
      return allItems.stream().filter(item -> id.equals(item.getId())).findFirst();

    } catch (FileNotFoundException e) {
      // TODO need to do something smarter here than bailing
      e.printStackTrace();
    } catch (IOException e) {
      // TODO need to do something smarter here than bailing
      e.printStackTrace();
    }
    return null;
  }

  @Override
  public void save(T item) {
    try (FileWriter fileWriter = new FileWriter(file)) {
      fileWriter.write(item.getId().toString());
    } catch (IOException e) {
      // TODO need to do something smarter here than bailing
      e.printStackTrace();
    }

  }

}
