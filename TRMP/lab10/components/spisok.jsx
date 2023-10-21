import React, {Component} from 'react';
import {
  StyleSheet,
  Text,
  View,
  FlatList,
  TouchableHighlight,
} from 'react-native';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [
        {key: 'a'},
        {key: 'b'},
        {key: 'c'},
        {key: 'd'},
        {key: 'e'},
        {key: 'f'},
        {key: 'g'},
        {key: 'h'},
        {key: 'i'},
        {key: 'j'},
        {key: 'k'},
        {key: 'l'},
        {key: 'm'},
        {key: 'n'},
        {key: 'o'},
        {key: 'p'},
      ],
    };
  }
  _LongPress = key => {
    let data = this.state.data.filter(item => !(item.key === key));
    this.setState({data});
  };
  render() {
    return (
      <View style={styles.container}>
        <FlatList
          data={this.state.data}
          renderItem={({item}) => (
            <RenderItem item={item} longPress={this._LongPress} />
          )}
        />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F5FCFF',
  },
  selectedRow: {backgroundColor: 'red'},
  row: {
    fontSize: 24,
    padding: 20,
    borderWidth: 1,
    borderColor: '#40e0d0',
    backgroundColor: '#40e0d0',
  },
});
export default App;

class RenderItem extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isRed: false,
    };
  }

  render() {
    return (
      <TouchableHighlight
        onPress={() => {
          this.setState({isRed: !this.state.isRed});
        }}
        onLongPress={() => this.props.longPress(this.props.item.key)}>
        <Text
          style={{
            ...styles.row,
            backgroundColor: this.state.isRed ? 'red' : '#40e0d0',
          }}>
          {this.props.item.key}
        </Text>
      </TouchableHighlight>
    );
  }
}
