import org.junit.jupiter.api.Test;

import java.util.List;
import java.util.Map;

import static org.junit.jupiter.api.Assertions.*;

public class VendingMachineTests {

    private static final Price DEFAULT_PRICE =
            new Price(List.of(new Dollar(), new Quarter(), new Quarter()));

    @Test
    public void testSetupWhenEmpty() {
        var vendingMachine = newEmptyVendingMachine();
        assertEquals(vendingMachine.availableChange(), Map.of());
        assertEquals(vendingMachine.availableItems(), Map.of());
    }

    @Test
    public void testSetupWithSameMoneyAndItems() {
        List<Money> availableChange = List.of(new Dollar());
        List<VendingMachine.Item> availableItems = List.of(newItemWithDefaultPrice("A"));

        var vendingMachine = newEmptyVendingMachine();
        vendingMachine.setup(availableChange, availableItems);
        assertEquals(vendingMachine.availableChange(), Map.of(new Dollar(), 1L));
        assertEquals(vendingMachine.availableItems(), Map.of(newItemWithDefaultPrice("A"), 1L));

        availableChange = List.of(new Dollar(), new Dollar());
        availableItems = List.of(newItemWithDefaultPrice("A"), newItemWithDefaultPrice("A"));

        vendingMachine.setup(availableChange, availableItems);
        assertEquals(vendingMachine.availableChange(), Map.of(new Dollar(), 2L));
        assertEquals(vendingMachine.availableItems(), Map.of(newItemWithDefaultPrice("A"), 2L));
    }

    @Test
    public void testSetupWithDifferentSortedMoneyAndItems() {
        List<Money> availableChange = List.of(new Dollar(), new Dollar(), new Quarter());
        List<VendingMachine.Item> availableItems = List.of(
                newItemWithDefaultPrice("A"),
                newItemWithDefaultPrice("A"),
                newItemWithDefaultPrice("B"));

        var vendingMachine = newEmptyVendingMachine();

        vendingMachine.setup(availableChange, availableItems);
        assertEquals(vendingMachine.availableChange(), Map.of(
                new Dollar(), 2L,
                new Quarter(), 1L));
        assertEquals(vendingMachine.availableItems(), Map.of(
                newItemWithDefaultPrice("A"), 2L,
                newItemWithDefaultPrice("B"), 1L));
    }

    @Test
    public void testSetupWithDifferentUnsortedMoneyAndItems() {
        var availableChange = List.of(new Quarter(), new Dollar(), new Quarter());
        var availableItems = List.of(
                newItemWithDefaultPrice("B"),
                newItemWithDefaultPrice("A"),
                newItemWithDefaultPrice("B"));

        var vendingMachine = newEmptyVendingMachine();

        vendingMachine.setup(availableChange, availableItems);
        assertEquals(vendingMachine.availableChange(), Map.of(
                new Dollar(), 1L,
                new Quarter(), 2L));
        assertEquals(vendingMachine.availableItems(), Map.of(
                newItemWithDefaultPrice("A"), 1L,
                newItemWithDefaultPrice("B"), 2L));
    }

    @Test
    public void testInsertedAmount() {
        var vendingMachine = newEmptyVendingMachine();
        vendingMachine.insert(new Quarter());
        assertEquals(vendingMachine.currentAmount().value(), 0.25);
        vendingMachine.insert(new Quarter());
        assertEquals(vendingMachine.currentAmount().value(), 0.5);
        vendingMachine.insert(new Dollar());
        assertEquals(vendingMachine.currentAmount().value(), 1.5);
    }

    private VendingMachine newEmptyVendingMachine() {
        return new VendingMachine(List.of(), List.of());
    }

    private VendingMachine.Item newItemWithDefaultPrice(String selector) {
        return new VendingMachine.Item(selector, DEFAULT_PRICE);
    }
}
