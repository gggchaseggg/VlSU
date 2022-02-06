import java.util.Scanner;

public class posled {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);

        System.out.println("Введите N: ");
        int N = console.nextInt();
        for (int i = 0; i < N+1; i++) {
            if (i % 3 == 0) {
                System.out.println("i=" + i + ": " + (N-i));
            }
            else if (i%3 == 1) {
                System.out.println("i=" + i + ": " + (i*2));
            }
            else {
                System.out.println("i=" + i + ": " + (i/3));
            }
        }
    }
}
