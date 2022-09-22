package ru.grachev.lab02;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

/**
 * Unit test for simple App.
 */
public class GreetingsBuilderTest {

    @Test
    public void testEnglish() {
        assertEquals(
            "Regular test work",
            GreetingsBuilder.formalInformalStyleEN("Daniil", true),
            "Hello, Daniil, glad to see you!");
    }
}
