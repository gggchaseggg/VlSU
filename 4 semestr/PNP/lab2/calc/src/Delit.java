public class Delit {
    protected float value1;
    protected float value2;

    public Delit(float x, float y) {
        this.value1 = x;
        this.value2 = y;
    }

    public float calc() {
        return this.value1/this.value2;
    }
}
