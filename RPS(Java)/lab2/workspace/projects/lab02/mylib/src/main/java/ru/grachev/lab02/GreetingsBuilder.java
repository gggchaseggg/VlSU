package ru.grachev.lab02;

/**
 * Hello world!
 *
 */
public class GreetingsBuilder {
    
    public static String formalInformalStyleRU(String name, boolean isFormalStyle) {
        return (isFormalStyle
        ? "Здравствуйте, " + name + ", рады вас видеть!"
        : "Дарова, " + name + ", чо как сам?");
    }

    public static String formalInformalStyleEN(String name, boolean isFormalStyle) {
        

        return (isFormalStyle
        ? "Hello, " + name + ", glad to see you!"
        : "Hi, " + name +", what's up?");
    }

}
