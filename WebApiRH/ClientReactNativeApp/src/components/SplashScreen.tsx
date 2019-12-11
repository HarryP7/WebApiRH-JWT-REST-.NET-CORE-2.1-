import React from 'react';
import {
  SafeAreaView, StyleSheet, ScrollView, View, Text, StatusBar, Image, Button,
} from 'react-native';
import {createAppContainer} from 'react-navigation';
import {createStackNavigator} from 'react-navigation-stack';
import Navigation from '..';
import {styles} from '.'

interface Props {}

class SplashScreen extends React.Component<any, Props> {
  static navigationOptions = {
    headerShown: false,
	};
  render() {
    const {body, sectionContainer,sectionTitle, sectionDescription, paddingBottom} = styles
    const {navigation} = this.props
    return (
          <View style={body}>
            <View style={sectionContainer}>
              <Text style={sectionTitle}>Управляй своим домом</Text>
            </View>
              <Text style={sectionDescription}>
                Данное приложение предназначено для упрощения взаимодействия 
                собственников квартир в многоэтажном доме с целью совместного управления домом.
              </Text>
            <View style={{ flex: 1, alignItems: 'center', justifyContent: 'flex-end' }}>
              <View style={paddingBottom}>
                <Image source={require('../../icon/bigHome.png')} style={styles.image}/>        
              </View>  
              <View style={paddingBottom}>         
                <Button
                    title="Продолжить"
                    color= '#009999'
                    onPress={() => navigation.navigate('Home')}
                  />
              </View>     
            </View> 
          </View>
  );
}
}

const RootStack = createStackNavigator(
  {
    Splash: SplashScreen,
    App: Navigation,
  },
  {
    initialRouteName: 'Splash',
    headerMode: 'none',
  }
);

export default createAppContainer(RootStack);
