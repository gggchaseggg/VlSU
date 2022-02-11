import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner Read = new Scanner(System.in);
        System.out.print("Какую операцию хотите выполнить [1(*)/2(/)]: ");
        Byte key = Read.nextByte();
        System.out.print("Введите первое число: ");
        float a = Read.nextFloat();
        System.out.print("Введите второе число: ");
        float b = Read.nextFloat();
        if (key == 1) {
            Mnoj ekz = new Mnoj(a,b);
            System.out.println("Результат выполнения действия: " + ekz.calc());
        }
        else if (key == 2) {
            if ( b != 0) {
                Delit ekz = new Delit(a,b);
                System.out.println("Результат выполнения действия: " + ekz.calc());
            }
            else {System.out.println("Нельзя делить на 0(вообще можно, но нельзя))");}
        }
        else {System.out.println("Такого действия нет(");}
    }
}
