import React, {useEffect} from 'react';
import {
  View, StyleSheet, Text, StatusBar, Image, Button, TextInput, Alert
} from 'react-native';
import { Header, styles } from '..';
import { backArrow } from '../../allSvg'
import { useGlobal, store } from '../../store'

class ProfileScreen extends React.Component<any> {
  state = {};
  
  componentDidMount = async () => {
    try {
      const token = '';
      const response = await fetch('http://192.168.43.80:5000/api/profile')
      const data = await response.json()
      this.setState({ data, load: true })
    } catch (e) {
      throw e
    }
  }

  render() {
    const { navigation } = this.props
    const { images,noImages, h1, container, indicator } = styles    
    var userLogin = store.state.userLogin;
    return (
      <View >
        <Header title='Профиль' 
          leftIcon={backArrow}
          onPressLeft={() => navigation.goBack()} />
          {userLogin.avatar ?
        <Image source={{uri: userLogin.avatar.url}}
          style={images}
        />
        : <Image source={require('../../../icon/user1.png')}
        style={noImages}
      />}
      <Text style={h1}>{userLogin.fullName} </Text>
      </View>
    )
  }
}

export { ProfileScreen };