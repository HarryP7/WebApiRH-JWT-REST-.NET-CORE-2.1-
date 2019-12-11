import * as React from 'react';
import {
  View, Text, TouchableHighlight, Image, ScrollView, Button, ActivityIndicator, Alert, ColorPropType
} from 'react-native';
import { createAppContainer } from 'react-navigation';
import { createStackNavigator } from 'react-navigation-stack';
import { createBottomTabNavigator } from 'react-navigation-tabs';
import { createDrawerNavigator, DrawerItems } from 'react-navigation-drawer';
import {
  HomeScreen, AddHomeScreen, NotificationScreen,
  ProfileScreen, AuthScreen, styles
} from './components';
import GroupScreen from './components/GroupTab/GroupScreen' 
import { SvgXml } from 'react-native-svg';
import { backArrow, login, addHome, home, group, notif, menu, search } from './allSvg'
import { brown } from './constants';
import { useGlobal, store } from './store'


const BottomTab = createBottomTabNavigator({
  Home: {
    screen: HomeScreen,
    navigationOptions: { tabBarLabel: 'Дом' },
  },
  Group: {
    screen: GroupScreen,
    navigationOptions: { tabBarLabel: 'Группы' },
  },
  Notification: {
    screen: NotificationScreen,
    navigationOptions: { tabBarLabel: 'Уведомления' },
  },
},
  {
    defaultNavigationOptions: ({ navigation }) => ({
      tabBarIcon: ({ focused, tintColor }) => {
        var { routeName } = navigation.state;
        return <SvgXml xml={
          routeName === 'Home' ? home : routeName === 'Group' ?
            group : routeName === 'Notification' ? notif : ''}
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
      drawerLabel: 'Вход | Регистрация',
      drawerIcon: () => <SvgXml xml={login} style={styles.icon} />
    },
  },
  AddHome: {
    screen: AddHomeScreen,
    navigationOptions: {
      drawerLabel: 'Добавить дом',
      drawerIcon: () => <SvgXml xml={addHome} style={styles.icon} />
    }
  },
}, {
  //initialRouteName: 'Tab',
  drawerBackgroundColor: brown,
  //drawerPosition: 'right',
  drawerType: 'front',
  drawerWidth: 220,
  swipeDistanceThreshold: 100,
  contentOptions: {
    itemConteinerStyle: {
      marginVertical: 10
    }
  }
});

const MainNavigation = createStackNavigator(
  {
    Drawer: MainDrawer,
  },
  {
    initialRouteName: 'Drawer',
    headerMode: 'none',
  }
);

export default createAppContainer(MainNavigation);
