import * as React from 'react';
import {
  View, Text, TouchableHighlight,
} from 'react-native';
import { NavigationStackScreenProps } from 'react-navigation-stack';
import { Header, styles } from '..';
import { SvgXml } from 'react-native-svg';
import { menu } from '../../allSvg'

interface Props { }

class NotificationScreen extends React.Component<any, Props> {

  render() {
    const { navigation } = this.props
    return (<View>
              <Header title='Уведомления'
                leftIcon={menu}
                onPressLeft={() => {
                  navigation.openDrawer()
                }} icon={menu} />
              <View style={{ alignItems: 'center', justifyContent: 'center' }}>
                <Text>My Notification Screen</Text>
              </View>
            </View>
    );
  }
}

export { NotificationScreen };