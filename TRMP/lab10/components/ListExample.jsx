import {StyleSheet, FlatList, View, Text, Image, Pressable} from 'react-native';
import {useState} from 'react';

const getRandomColor = () => {
  const letters = '0123456789ABCDEF';
  let hex = '#';
  for (let i = 0; i < 6; i++) {
    hex += letters[Math.floor(Math.random() * 15)];
  }
  return hex;
};

const ListExample = () => {
  const [data, setData] = useState([
    {
      key: '1',
      name: 'Война и Мир',
      description: 'Написал Толстой',
      photo: require('../assets/War.jpg'),
    },
    {
      key: '2',
      name: 'Капитанская дочка',
      description: 'Написал Пушкин',
      photo: require('../assets/daughter.jpeg'),
    },
    {
      key: '3',
      name: 'Повесть о настоящем человеке',
      description: 'Написал Полевой',
      photo: require('../assets/povest.jpg'),
    },
    {
      key: '4',
      name: 'Преступление и наказание',
      description: 'Написал Достоевский',
      photo: require('../assets/nakaz.jpg'),
    },
    {
      key: '5',
      name: '1984',
      description: 'Написал Оруэлл',
      photo: require('../assets/dev.jpg'),
    },
  ]);

  const handleLongPress = key => {
    setData(prevState => prevState.filter(item => item.key !== key));
  };

  const RenderItem = ({item}) => {
    const [color, setColor] = useState('transparent');

    const handleTouchRow = key => {
      setColor(getRandomColor);
    };

    return (
      <Pressable
        onPress={() => handleTouchRow(item.key)}
        onLongPress={() => handleLongPress(item.key)}>
        <View
          style={{
            ...styles.row,
            backgroundColor: color,
          }}>
          <Image source={item.photo} style={styles.image} />
          <View>
            <Text style={styles.text}>{item.name}</Text>
            <Text style={styles.text}>{item.description}</Text>
          </View>
        </View>
      </Pressable>
    );
  };

  return (
    <View style={styles.container}>
      <FlatList
        data={data}
        renderItem={({item}) => <RenderItem item={item} />}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    color: 'black',
    padding: 15,
  },
  text: {
    color: 'black',
  },
  image: {
    width: 150,
    height: 150,
  },
  row: {
    display: 'flex',
    flexDirection: 'row',
    marginBottom: 15,
    columnGap: 20,
    paddingBottom: 15,
    borderBottomWidth: 1,
  },
});

export default ListExample;
