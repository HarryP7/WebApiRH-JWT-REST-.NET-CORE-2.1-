
import React from 'react';
import {
  StyleSheet, View, Text, TouchableOpacity, TextInput
} from 'react-native';
import { SvgXml } from 'react-native-svg';
import { h, w } from '../constants'


const SearchBar = ({ onPressRight, rightIcon, onChangeText, value, onBlur }: any) => {
  const { container, sub, iconRightStyle, input } = styles
  return (
          <View style={container}>
            <View style={sub}>
              <TextInput
                style={input}
                onChangeText={onChangeText}
                placeholder='Поиск..'      
                //value={value}
                onBlur={onBlur}        
              />
              <TouchableOpacity onPress={onPressRight} >
                {/* <View style={searchStyle}></View> */}
                <SvgXml xml={rightIcon}
                  style={iconRightStyle} fill='#fff' />
              </TouchableOpacity>
            </View>
          </View>
  )
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: '#92582D',
    height: 60,
    justifyContent: 'center',
    alignItems: 'center',
    position: 'relative',
    // ...ifIphoneX(
    //   {height: 122},
    //   {height: 90}
    // })
  },  
  iconRightStyle: {    
    width: 25,
    height: 25,
    marginLeft: 5,
    marginRight: 15,
    marginTop: 7,
  },
  sub: {
    justifyContent: 'space-between',
    flexDirection: 'row',
    backgroundColor: "#4d2b04",
    width: w * 0.95,
    borderRadius: 20,
    marginLeft: 5,
  },
  input: {
    fontSize: 16,
    height: 40,
    width: w *0.85,
    backgroundColor: '#fff',
    borderRadius: 20,
    paddingHorizontal: 10,
  }
})

export { SearchBar }
