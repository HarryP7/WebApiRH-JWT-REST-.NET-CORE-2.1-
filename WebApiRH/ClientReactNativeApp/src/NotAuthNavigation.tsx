import * as React from 'react';
import {
  View, Text, TouchableHighlight, Image, ScrollView, Button, ActivityIndicator, Alert, ColorPropType
} from 'react-native';
import { createAppContainer } from 'react-navigation';
import { createStackNavigator } from 'react-navigation-stack';
import { createBottomTabNavigator } from 'react-navigation-tabs';
import { createDrawerNavigator, DrawerItems } from 'react-navigation-drawer';
import {
  SearchHomeScreen, ProfileScreen, AuthScreen, RegistrationScreen, styles
} from './components';
import HomeScreen from './components/HomeTab/HomeScreen' 
import { SvgXml } from 'react-native-svg';
import { backArrow, login,  home, searchHome, notif, menu, search } from './allSvg'
import { brown } from './constants';
import { Icon } from 'react-native-elements';


const BottomTab = createBottomTabNavigator({
  Home: {
    screen: HomeScreen,
    navigationOptions: { tabBarLabel: 'Дом' },
  },
  SearchHome: {
    screen: SearchHomeScreen,
    navigationOptions: { tabBarLabel: 'Поиск дома' },
  },
},
  {
    defaultNavigationOptions: ({ navigation }) => ({
      tabBarIcon: ({ focused, tintColor }) => {
        var { routeName } = navigation.state;
        return <SvgXml xml={
          routeName === 'Home' ? home : routeName === 'SearchHome' ?
          searchHome : routeName === 'Notification' ? notif : ''}
          style={styles.icon} fill={tintColor} />
      },
    }),
    tabBarOptions: {
      activeTintColor: brown,
      inactiveTintColor: 'gray',
    },
  }
);

const BottomTabStack = createStackNavigator({
  BottomTabStack: { screen: BottomTab },
},
  { headerMode: 'none', }
);


const MainDrawer = createDrawerNavigator({
  Tab: {
    screen: BottomTabStack,
    navigationOptions: {
      drawerLabel: ' ',
      drawerIcon: () =>
        <SvgXml xml={backArrow} width="20" height="20" style={styles.back} />
    }
  },
  Profile: {
    screen: ProfileScreen,
    navigationOptions: {
      drawerLabel: ' ',
      drawerIcon: () => <Image
        source={require('../icon/user1.png')}
        style={styles.imageIcon} />
    }
  },
  Auth: {
    screen: AuthScreen,
    navigationOptions: {
      drawerLabel: 'Вход',
      drawerIcon: () => <SvgXml xml={login} style={styles.icon} />
    },
  },
  Registretion: {
    screen: RegistrationScreen,
    navigationOptions: {
      drawerLabel: 'Регистрация',
      drawerIcon: () => <Icon name="library-books" size={25}></Icon> //library-books, data-usage
    },
  },
}, {
  drawerBackgroundColor: brown,
  drawerType: 'front',
  drawerWidth: 220,
  swipeDistanceThreshold: 100,
  contentOptions: {
    itemConteinerStyle: {
      marginVertical: 10
    }
  }
});

const NotAuthNavigation = createStackNavigator(
  {
    Drawer: MainDrawer,
  },
  {
    initialRouteName: 'Drawer',
    headerMode: 'none',
  }
);

export default createAppContainer(NotAuthNavigation);
