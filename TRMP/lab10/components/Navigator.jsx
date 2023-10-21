import React from 'react';
import {createNativeStackNavigator} from '@react-navigation/native-stack';
import ButtonExample from './ButtonExample';
import HelloWorld from './HelloWorld';
import ListExample from './ListExample';
import Main from './Main';
import App from './spisok';
const Navigator = () => {
  const Stack = createNativeStackNavigator();

  return (
    <Stack.Navigator initialRouteName={'Main'}>
      <Stack.Screen name={'Main'} component={Main} />
      <Stack.Screen name={'Button'} component={ButtonExample} />
      <Stack.Screen name={'HelloWorld'} component={HelloWorld} />
      <Stack.Screen name={'ListExample'} component={ListExample} />
    </Stack.Navigator>
  );
};

export default Navigator;
