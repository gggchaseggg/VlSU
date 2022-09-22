package ru.grachev.lab02;
import ru.grachev.lab02.GreetingsBuilder;
import com.joanzapata.utils.Strings;


public class ApplicationRU {

	public static void main(String[] args) {
		System.out.println("Привет мир!");
		String nameRU = "Даниил";
		System.out.println(Strings.format("stroka").build());
		System.out.println();


		System.out.println(GreetingsBuilder.formalInformalStyleRU(nameRU, false));
		System.out.println(GreetingsBuilder.formalInformalStyleRU(nameRU, true));

	}
	
}