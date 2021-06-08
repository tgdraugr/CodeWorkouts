import java.util.List;

public class Price {
    private final Amount amount;

    public Price(List<Money> value) {
        this(new Amount(value));
    }

    public Price(Amount amount) {
        this.amount = amount;
    }

    public List<Money> money() {
        return this.amount.money();
    }

    public double value() {
        return this.amount.value();
    }
}
