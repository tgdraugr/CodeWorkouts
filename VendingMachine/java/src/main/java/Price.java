import java.util.List;

public class Price {
    private final List<Money> value;

    public Price(List<Money> value) {
        this.value = value;
    }

    public double value() {
        return this.value
                .stream()
                .mapToDouble(Money::value)
                .sum();
    }
}
