import java.util.List;

public class Amount {
    private final List<Money> value;

    public Amount(List<Money> value) {
        this.value = value;
    }

    public double value() {
        return this.value
                .stream()
                .mapToDouble(Money::value)
                .sum();
    }
}
