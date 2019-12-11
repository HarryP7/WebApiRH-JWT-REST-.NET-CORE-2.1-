
import React from 'react';
import {
  StyleSheet, View, Text, TouchableOpacity
} from 'react-native';
import { SvgXml } from 'react-native-svg';
import { h, w } from '../constants'


const Header = ({ title, onPressLeft, leftIcon, onPressRight, rightIcon }: any) => {
  const { container, titleStyle, iconLeftStyle, iconRightStyle } = styles
  return (
          <View style={container}>
            {leftIcon && 
              <TouchableOpacity onPress={onPressLeft} >
                <SvgXml
                  xml={leftIcon}
                  style={iconLeftStyle} fill='#fff' />
              </TouchableOpacity>
            }
            <Text style={titleStyle}>{title}</Text>
            {rightIcon && 
              <TouchableOpacity onPress={onPressRight} >
                <SvgXml
                  xml={rightIcon}
                  style={iconRightStyle} fill='#fff' />
              </TouchableOpacity>
            }
          </View>
  )
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: '#92582D',
    height: 60,
    flexDirection: 'row',
    //justifyContent: 'space-between',
    alignItems: 'center',
    position: 'relative',
    // ...ifIphoneX(
    //   {height: 122},
    //   {height: 90}
    // })
  },
  titleStyle: {
    fontSize: 24,
    paddingLeft: 20,
    color: '#fff',
    fontWeight: 'bold',
  },
  iconLeftStyle: {
    width: 20,
    height: 20,
    marginLeft: 20,
  },
  iconRightStyle: {    
    width: 25,
    height: 25,
    marginLeft: w * 0.53
  }
})

export { Header }
