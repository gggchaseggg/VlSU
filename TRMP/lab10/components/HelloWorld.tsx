import {StyleSheet, Text, View} from 'react-native';

const HelloWorld = () => {
  return (
    <View style={styles.container}>
      <Text style={{color: 'black'}}>Hello, world!</Text>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});

export default HelloWorld;
