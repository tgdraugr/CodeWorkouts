import java.util.Objects;

public abstract class Money {
    private final String name;
    private final double value;

    protected Money(String name, double value) {
        this.name = name;
        this.value = value;
    }

    public String name() {
        return this.name;
    }

    public double value() {
        return this.value;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Money money = (Money) o;
        return Double.compare(money.value, value) == 0 && Objects.equals(name, money.name);
    }

    @Override
    public int hashCode() {
        return Objects.hash(name, value);
    }
}
