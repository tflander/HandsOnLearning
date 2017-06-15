import static org.junit.Assert.*;

import org.junit.Test;

import java.util.Arrays;
import java.util.List;


public class GildedRoseTest {

  @Test
  public void itemsDoNotDecreaseInQualityBelowZero() {
    // Arrange
    Item item = new Item("Sword", 3, 0);
    List<Item> items = Arrays.asList(item);
    GildedRose gildedRose = new GildedRose(items);

    // Act
    gildedRose.updateQuality();

    // Assert
    assertEquals(0, item.getQuality());
  }
  
  @Test
  public void eachDayTheSellInCounterGoesDownByOne() {
    // Arrange
    Item item = new Item("Sword", 3, 0);
    List<Item> items = Arrays.asList(item);
    GildedRose gildedRose = new GildedRose(items);

    // Act
    gildedRose.updateQuality();

    // Assert
    assertEquals(2, item.getSellIn());
  }
  
  @Test
  public void eachDayTheQualityOfATypicalItemGoesDown() {
    // Arrange
    Item item = new Item("Sword", 3, 17);
    List<Item> items = Arrays.asList(item);
    GildedRose gildedRose = new GildedRose(items);

    // Act
    gildedRose.updateQuality();

    // Assert
    assertEquals(16, item.getQuality());
  }
  
  @Test
  public void afterThreeDaysTheQualityShouldBeThreeLessThanItStarted() {
    // Arrange
    Item item = new Item("Sword", 3, 17);
    List<Item> items = Arrays.asList(item);
    GildedRose gildedRose = new GildedRose(items);

    // Act
    gildedRose.updateQuality();
    gildedRose.updateQuality();
    gildedRose.updateQuality();

    // Assert
    assertEquals(14, item.getQuality());
  }
  
  @Test
  public void afterTheSellByDateQualityDecreasesByTwo() {
    // Arrange
    Item item = new Item("Sword", 0, 17);
    List<Item> items = Arrays.asList(item);
    GildedRose gildedRose = new GildedRose(items);

    // Act
    gildedRose.updateQuality();

    // Assert
    assertEquals(15, item.getQuality());
  }
  
  @Test
  public void agedBrieActuallyIncreaseInQualityOverTime() {
    // Arrange
    Item item = new Item("Aged Brie", 6, 2);
    List<Item> items = Arrays.asList(item);
    GildedRose gildedRose = new GildedRose(items);

    // Act
    gildedRose.updateQuality();

    // Assert
    assertEquals(3, item.getQuality());
  }
  
  @Test
  public void agedBrieQualityGoesUpTwiceAsFastAfterSellByDate() {
    // Arrange
    Item item = new Item("Aged Brie", 0, 5);
    List<Item> items = Arrays.asList(item);
    GildedRose gildedRose = new GildedRose(items);

    // Act
    gildedRose.updateQuality();

    // Assert
    assertEquals(7, item.getQuality());
  }
  
  @Test
  public void agedBrieQualityNeverGoesOverFifty() {
    // Arrange
    Item item = new Item("Aged Brie", 4, 49);
    List<Item> items = Arrays.asList(item);
    GildedRose gildedRose = new GildedRose(items);

    // Act
    gildedRose.updateQuality();
    gildedRose.updateQuality();
    gildedRose.updateQuality();
    gildedRose.updateQuality();

    // Assert
    assertEquals(50, item.getQuality());
  }
  
  @Test
  public void agedBrieKeepsItsInitialQualityIfItIsAlreadyOverFifty() {
    // Arrange
    Item item = new Item("Aged Brie", 4, 75);
    List<Item> items = Arrays.asList(item);
    GildedRose gildedRose = new GildedRose(items);

    // Act
    gildedRose.updateQuality();

    // Assert
    assertEquals(75, item.getQuality());
  }
  
  
  @Test
  public void agedBrieQualityNeverGoesOverFiftyEvenIfPastTheSellByDate() {
    // Arrange
    Item item = new Item("Aged Brie", 0, 49);
    List<Item> items = Arrays.asList(item);
    GildedRose gildedRose = new GildedRose(items);

    // Act
    gildedRose.updateQuality();

    // Assert
    assertEquals(50, item.getQuality());
  }
  
  
  
}
