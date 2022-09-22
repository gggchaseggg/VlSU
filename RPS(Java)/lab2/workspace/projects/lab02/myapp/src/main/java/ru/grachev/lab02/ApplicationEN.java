package ru.grachev.lab02;
import ru.grachev.lab02.GreetingsBuilder;
import com.joanzapata.utils.Strings;


public class ApplicationEN {

	public static void main(String[] args) {
		System.out.println("Привет мир!");
		String nameEN = "Daniil";
		System.out.println(Strings.format("stroka").build());
		System.out.println();


		System.out.println(GreetingsBuilder.formalInformalStyleEN(nameEN, false));
		System.out.println(GreetingsBuilder.formalInformalStyleEN(nameEN, true));

	}
	
}