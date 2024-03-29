import java.util.*;
import java.util.function.Function;
import java.util.stream.Collectors;

public class VendingMachine {
    private final List<Money> insertedMoney;
    private List<Money> availableChange;
    private List<Item> availableItems;

    public VendingMachine(List<Money> availableChange, List<Item> availableItems) {
        this(availableChange, availableItems, new ArrayList<>());
    }

    protected VendingMachine(List<Money> availableChange, List<Item> availableItems, List<Money> insertedMoney) {
        setup(availableChange, availableItems);
        this.insertedMoney = insertedMoney;
    }

    public Map<Money, Long> availableChange() {
        return Grouped(this.availableChange);
    }

    public Map<Item, Long> availableItems() {
        return Grouped(this.availableItems);
    }

    public void setup(List<Money> availableChange, List<Item> availableItems) {
        this.availableChange = new ArrayList<>(availableChange);
        this.availableItems = new ArrayList<>(availableItems);
    }

    public void insert(Money money) {
        this.insertedMoney.add(money);
    }

    public Amount currentAmount() {
        return new Amount(this.insertedMoney);
    }

    public Amount refund() {
        var amount = new Amount(new ArrayList<>(this.insertedMoney));
        this.insertedMoney.clear();
        return amount;
    }

    public Item selectItem(String selector) {
        var selectedItem = item(selector);

        selectedItem.ifPresent(item -> {
            this.availableChange.addAll(item.price.money());
            this.availableItems.remove(item);
        });

        return selectedItem.orElse(null);
    }

    private Optional<Item> item(String selector) {
        for (var item : this.availableItems) {
            if (item.selector.equals(selector)) {
                return Optional.of(item);
            }
        }
        return Optional.empty();
    }

    private <E> Map<E, Long> Grouped(List<E> elements) {
        return elements
                .stream()
                .collect(Collectors.groupingBy(Function.identity(), Collectors.counting()));
    }

    public static class Item {
        private final String selector;
        private final Price price;

        public Item(String selector, Price price) {
            this.selector = selector;
            this.price = price;
        }

        public double value() {
            return this.price.value();
        }

        public String selector() {
            return this.selector;
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;
            Item item = (Item) o;
            return Objects.equals(selector, item.selector);
        }

        @Override
        public int hashCode() {
            return Objects.hash(selector);
        }
    }
}
