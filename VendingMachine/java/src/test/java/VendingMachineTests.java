import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.List;
import java.util.Map;

import static org.junit.jupiter.api.Assertions.*;

public class VendingMachineTests {

    private static final Price DEFAULT_PRICE =
            new Price(List.of(new Dollar(), new Quarter(), new Quarter()));

    private VendingMachine vendingMachine;

    @BeforeEach
    public void beforeEachTest() {
        vendingMachine = new VendingMachine(List.of(), List.of());
    }

    @Test
    public void shouldNotHaveAvailableItems() {
        assertEquals(vendingMachine.availableItems(), Map.of());
    }

    @Test
    public void shouldNotHaveAvailableChange() {
        assertEquals(vendingMachine.availableChange(), Map.of());
    }

    @Test
    public void shouldHaveAvailableChangeWhenSetup() {
        vendingMachine.setup(List.of(new Dollar()), List.of());
        assertEquals(vendingMachine.availableChange(), Map.of(new Dollar(), 1L));
    }

    @Test
    public void shouldHaveAvailableChangeWhenSetupWithSortedApproach() {
        List<Money> availableChange = List.of(new Dollar(), new Dollar(), new Quarter());
        vendingMachine.setup(availableChange, List.of());
        var expectedChange = Map.of(new Dollar(), 2L, new Quarter(), 1L);
        assertEquals(vendingMachine.availableChange(), expectedChange);
    }

    @Test
    public void shouldHaveAvailableChangeWhenSetupWithUnsortedApproach() {
        List<Money> availableChange = List.of(new Dollar(), new Quarter(), new Dollar());
        vendingMachine.setup(availableChange, List.of());
        var expectedChange = Map.of(new Dollar(), 2L, new Quarter(), 1L);
        assertEquals(vendingMachine.availableChange(), expectedChange);
    }

    @Test
    public void shouldHaveAvailableItemsWhenSetup() {
        var availableItems = List.of(newItemWithDefaultPrice("A"));
        vendingMachine.setup(List.of(), availableItems);
        assertEquals(vendingMachine.availableItems(), Map.of(newItemWithDefaultPrice("A"), 1L));
    }

    @Test
    public void shouldHaveAvailableItemsWhenSetupWithSortedApproach() {
        var availableItems = List.of(
                newItemWithDefaultPrice("A"),
                newItemWithDefaultPrice("A"),
                newItemWithDefaultPrice("B"));
        vendingMachine.setup(List.of(), availableItems);
        var expectedItems = Map.of(
                newItemWithDefaultPrice("A"), 2L,
                newItemWithDefaultPrice("B"), 1L);
        assertEquals(vendingMachine.availableItems(), expectedItems);
    }

    @Test
    public void shouldHaveAvailableItemsWhenSetupWithUnsortedApproach() {
        var availableItems = List.of(
                newItemWithDefaultPrice("B"),
                newItemWithDefaultPrice("A"),
                newItemWithDefaultPrice("B"));
        vendingMachine.setup(List.of(), availableItems);
        var expectedItems = Map.of(
                newItemWithDefaultPrice("A"), 1L,
                newItemWithDefaultPrice("B"), 2L);
        assertEquals(vendingMachine.availableItems(), expectedItems);
    }

    @Test
    public void shouldTrackInsertedAmount() {
        vendingMachine.insert(new Quarter());
        assertEquals(vendingMachine.currentAmount().value(), 0.25);
        vendingMachine.insert(new Quarter());
        assertEquals(vendingMachine.currentAmount().value(), 0.5);
        vendingMachine.insert(new Dollar());
        assertEquals(vendingMachine.currentAmount().value(), 1.5);
    }

    @Test
    public void shouldRefundInsertedAmount() {
        vendingMachine.insert(new Dollar());
        vendingMachine.insert(new Dollar());
        var amount = vendingMachine.refund();
        assertEquals(amount.value(), 2.0);
        assertEquals(vendingMachine.currentAmount().value(), 0.0);
    }

    @Test
    public void shouldAllowItemSelectionWithExactAmount() {
        var price = new Price(List.of(new Dollar()));
        var item = newItem("A", price);
        vendingMachine.setup(List.of(), List.of(item));
        vendingMachine.insert(new Dollar());
        var selectedItem = vendingMachine.selectItem("A");
        assertEquals(item, selectedItem);
        assertEquals(vendingMachine.availableItems(), Map.of());
        assertEquals(vendingMachine.availableChange(), Map.of(new Dollar(), 1L));
    }

    private VendingMachine.Item newItemWithDefaultPrice(String selector) {
        return newItem(selector, DEFAULT_PRICE);
    }

    private VendingMachine.Item newItem(String selector, Price price) {
        return new VendingMachine.Item(selector, price);
    }
}
