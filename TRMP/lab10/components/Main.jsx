import React from 'react';
import {StyleSheet, View} from 'react-native';
import {Link} from '@react-navigation/native';

const Main = () => {
  return (
    <View style={styles.container}>
      <Link to={'/Button'} style={styles.link}>
        Button
      </Link>
      <Link to={'/HelloWorld'} style={styles.link}>
        Hello World
      </Link>
      <Link to={'/ListExample'} style={styles.link}>
        List Example
      </Link>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'space-evenly',
    alignItems: 'center',
    backgroundColor: '#F5FCFF',
    color: 'black',
  },
  link: {
    color: 'black',
  },
});

export default Main;
