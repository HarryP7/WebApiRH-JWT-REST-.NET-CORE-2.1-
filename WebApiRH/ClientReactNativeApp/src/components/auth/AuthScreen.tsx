import React, { PureComponent, useState, useEffect } from 'react';
import {
  StyleSheet, ScrollView, View, Text, TouchableOpacity, TextInput, Alert, ActivityIndicator
} from 'react-native';

import { SvgXml } from 'react-native-svg';
import { user, homeLoc, lock, lockRep, shield } from '../../allSvg'
import { Header } from '..';
import { h, w } from '../../constants'
import { backArrow } from '../../allSvg'
import { User } from '../../interfaces'
import { actions } from '../../store'

interface Props { }
interface State { }
interface AuthData {
  token: string,
  userLogin: User,
}
var arr: boolean[] = [];
var arrText: string[] = [];
var arrColor: string[] = [];


class AuthScreen extends PureComponent<any, State, Props> {
  state = {
    login: '', address: '', name: '', surname: '',
    password: '', repeatPassword: '', color: '#000',
    signup: false, good: true, passGood: false, submit: false,
    badEnter: arr, errorText: arrText, colorIcon: arrColor,
  }

  render() {
    console.log('Props AuthScreen', this.props)
    const { signup, login, address, name, surname, password, color,
      repeatPassword, badEnter, errorText, colorIcon, passGood, submit } = this.state
    const { navigation } = this.props
    const { fixToText, icon, textInput, input, button, buttonContainer, buttonTitle, indicator,
      link, error, inputMultiline } = styles
    return (
      <View>
        <Header title={signup ? 'Регистрация' : 'Вход'}
          leftIcon={backArrow}
          onPressLeft={() => {
            this.setClearState()
            navigation.goBack();
          }}
        />
        <ScrollView>
          {submit && <ActivityIndicator style={indicator} size={70} color="#92582D" />}
          <View style={fixToText}>
            <SvgXml xml={user} style={icon} fill={color} />
            <View style={textInput}>
              <TextInput
                style={input}
                onChangeText={this.onChangeLogin.bind(this)}
                placeholder='Логин'
                autoCompleteType='name'
                value={login}
                onEndEditing={() => this.onCheckLogin(login)}
              />
              {badEnter[0] && <Text style={error}>{errorText[0]}</Text>}
            </View>
          </View>
          {signup && <View>
            <View style={fixToText}>
              <SvgXml xml={homeLoc} style={icon} fill={color} />
              <View style={textInput}>
                <TextInput
                  style={inputMultiline}
                  onChangeText={this.onChangeAddress.bind(this)}
                  placeholder='Адрес'
                  autoCorrect={true}
                  value={address}
                  multiline={true}
                  numberOfLines={1}
                  onEndEditing={() => this.onCheckAddress(address)}
                />
                {badEnter[1] && <Text style={error}>{errorText[1]}</Text>}
              </View>
            </View>
            <View style={fixToText}>
              <SvgXml xml={user} style={icon} fill={color} />
              <View style={textInput}>
                <TextInput
                  style={input}
                  onChangeText={this.onChangeName.bind(this)}
                  placeholder='Имя'
                  value={name}
                  onEndEditing={() => this.onCheckName(name)}
                />
                {badEnter[2] && <Text style={error}>{errorText[2]}</Text>}
              </View>
            </View>
            <View style={fixToText}>
              <SvgXml xml={user} style={icon} fill={color} />
              <View style={textInput}>
                <TextInput
                  style={input}
                  onChangeText={this.onChangeSurname.bind(this)}
                  placeholder='Фамилия'
                  value={surname}
                  onEndEditing={() => this.onCheckSurname(surname)}
                />
                {badEnter[3] && <Text style={error}>{errorText[3]}</Text>}
              </View>
            </View>
          </View>
          }

          <View style={fixToText}>
            <SvgXml xml={lock} style={icon} fill={colorIcon[4]} />
            <View style={textInput}>
              <TextInput
                style={input}
                onChangeText={this.onChangePassword.bind(this)}
                placeholder='Пароль'
                autoCompleteType='password'
                textContentType='password'
                secureTextEntry={true}
                value={password}
                onEndEditing={() => this.onCheckPass(password)}
              />
              {badEnter[4] && <Text style={error}>{errorText[4]}</Text>}
            </View>
          </View>

          {signup ? <View>
            <View style={fixToText}>
              <SvgXml xml={passGood ? shield : lockRep} style={icon}
                fill={colorIcon[5]} />
              <View style={textInput}>
                <TextInput
                  style={input}
                  onChangeText={this.onChangeRepeatPassword.bind(this)}
                  placeholder='Повторите пароль'
                  autoCompleteType={'password'}
                  textContentType={'password'}
                  secureTextEntry={true}
                  value={repeatPassword}
                  onEndEditing={() => this.onCheckRep(repeatPassword)}
                />
                {badEnter[5] && <Text style={error}>{errorText[5]}</Text>}
              </View>
            </View>

            <View style={{ alignItems: 'center' }}>
              <View style={button}>
                <TouchableOpacity
                  onPress={this.onSubmit.bind(this)}
                  disabled={submit} >
                  <View style={buttonContainer}>
                    <Text style={buttonTitle}>Подтверить и создать</Text>
                  </View>
                </TouchableOpacity>
              </View>
            </View>
          </View>
            :
            <View style={{ alignItems: 'center' }}>
              <View style={button}>
                <TouchableOpacity
                  onPress={this.onSubmit.bind(this)}
                  disabled={submit}>
                  <View style={buttonContainer}>
                    <Text style={buttonTitle}>Войти</Text>
                  </View>
                </TouchableOpacity>
              </View>
            </View>}

          <TouchableOpacity
            onPress={this.onPress.bind(this)}
            disabled={submit} >
            <Text style={link}>{signup ? 'Вход' : 'Регистрация'}</Text>
          </TouchableOpacity>
          <View style={{margin: 50}}><Text> </Text></View>
        </ScrollView>
      </View>
    );
  }

  private onPress() {
    this.setClearState();
    this.setState({ signup: !this.state.signup });
  }

  private onChangeLogin(login: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (!login) {
      badEnter[0] = true;
      errorText[0] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, login, good: false });
      return;
    }
    badEnter[0] = false;
    this.setState({ login, good: true });
  }
  private onCheckLogin(login: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (login.length < 4 || login.length > 20) {
      badEnter[0] = true;
      errorText[0] = 'Логин должен быть длиной от 4 до 20 символов!'
      this.setState({ badEnter, errorText, login, good: false });
      return;
    }
    badEnter[0] = false;
    this.setState({ login, badEnter, good: true });
  }
  private onChangeAddress(address: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (!address) {
      badEnter[1] = true;
      errorText[1] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, address, good: false });
      return;
    }
    badEnter[1] = false;
    this.setState({ address, good: true });
  }
  private onCheckAddress(address: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (address.length < 20) {
      badEnter[1] = true;
      errorText[1] = 'Введите полный адрес!'
      this.setState({ badEnter, errorText, address, good: false });
      return;
    }
    badEnter[1] = false;
    this.setState({ address, badEnter, good: true });
  }
  private onChangeName(name: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (!name) {
      badEnter[2] = true;
      errorText[2] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, name, good: false });
      return;
    }
    badEnter[2] = false;
    this.setState({ name, good: true });
  }
  private onCheckName(name: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (name.length < 2 || name.length > 25) {
      badEnter[2] = true;
      errorText[2] = 'Имя должно быть больше 1 символа и меньше 25!'
      this.setState({ badEnter, errorText, name, good: false });
      return;
    }
    badEnter[2] = false;
    this.setState({ name, badEnter, good: true });
  }
  private onChangeSurname(surname: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    if (!surname) {
      badEnter[3] = true;
      errorText[3] = 'Поле не заполнено!'
      this.setState({ badEnter, errorText, surname, good: false });
      return;
    }
    badEnter[3] = false;
    this.setState({ surname, good: true });
  }
  private onCheckSurname(surname: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    var colorIcon = this.state.colorIcon
    if (surname.length < 2 || surname.length > 25) {
      badEnter[3] = true;
      errorText[3] = 'Фамилия должна быть больше 1 символа и меньше 25!'
      this.setState({ badEnter, errorText, surname, good: false });
      return;
    }
    badEnter[3] = false;
    colorIcon[3] = 'green'
    this.setState({ surname, badEnter, colorIcon, good: true });
  }
  private onChangePassword(password: string) {
    var badEnter = this.state.badEnter
    var colorIcon = this.state.colorIcon
    if (password.length >= 8) {
      badEnter[4] = false
      colorIcon[4] = 'green'
      this.setState({ colorIcon, badPass: false });
    }
    this.setState({ password });
  }
  private onCheckPass(pass: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    var colorIcon = this.state.colorIcon
    if (pass.length < 8) {
      badEnter[4] = true;
      errorText[4] = 'Пароль должен иметь длину не менее 8 знаков!'
      colorIcon[4] = 'red'
      this.setState({ badEnter, errorText, colorIcon, pass, good: false });
      return;
    }
  }
  private onChangeRepeatPassword(repeatPassword: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    var colorIcon = this.state.colorIcon
    var pass = this.state.password;
    if (pass.length == repeatPassword.length && pass === repeatPassword) {
      badEnter[5] = false;
      colorIcon[5] = 'green'
      this.setState({ badEnter, colorIcon, passGood: true, good: true });
    }
    else if (pass.length == repeatPassword.length) {
      badEnter[5] = true;
      errorText[5] = 'Пароли не совпадают!'
      colorIcon[5] = 'red'
      this.setState({ badEnter, errorText, colorIcon, passGood: false, good: false });
    }
    this.setState({ repeatPassword });
  }
  private onCheckRep(repeatPassword: string) {
    var badEnter = this.state.badEnter
    var errorText = this.state.errorText
    var colorIcon = this.state.colorIcon
    var pass = this.state.password;
    if (pass !== repeatPassword) {
      badEnter[5] = true;
      errorText[5] = 'Пароли не совпадают!'
      colorIcon[5] = 'red'
      this.setState({ badEnter, errorText, colorIcon, passGood: false, good: false });
    }
  }


  private onSubmit() {
    const { signup, login, address, name, surname, password, repeatPassword, badEnter, errorText, colorIcon, good } = this.state
    const { navigation } = this.props
    var $this = this;
    var obj, url, log: string;
    if (!login) {
      badEnter[0] = true;
      errorText[0] = 'Поле не заполнено!'
      colorIcon[0] = 'red'
      this.setState({ badEnter, errorText, colorIcon, good: false });
    }
    if (!password) {
      badEnter[4] = true;
      errorText[4] = 'Поле не заполнено!'
      colorIcon[4] = 'red'
      this.setState({ badEnter, errorText, colorIcon, good: false });
    }
    if (signup) {
      if (!address) {
        badEnter[1] = true;
        errorText[1] = 'Поле не заполнено!'
        colorIcon[1] = 'red'
        this.setState({ badEnter, errorText, colorIcon, good: false });
      }
      if (!name) {
        badEnter[2] = true;
        errorText[2] = 'Поле не заполнено!'
        colorIcon[2] = 'red'
        this.setState({ badEnter, errorText, colorIcon, good: false });
      }
      if (!surname) {
        badEnter[3] = true;
        errorText[3] = 'Поле не заполнено!'
        colorIcon[3] = 'red'
        this.setState({ badEnter, errorText, colorIcon, good: false });
      }
      if (!repeatPassword) {
        badEnter[5] = true;
        errorText[5] = 'Поле не заполнено!'
        colorIcon[5] = 'red'
        this.setState({ badEnter, errorText, colorIcon, good: false });
      }
      if (!login || !address || !name ||
        !surname || !password || !repeatPassword) {
        Alert.alert('Внимание', 'Не все поля заполнены!',
          [{ text: 'OK' }],
          { cancelable: false },
        );
        return;
      }
      else if (password !== repeatPassword) {
        badEnter[5] = true;
        errorText[5] = 'Пароли не совпадают!'
        colorIcon[5] = 'red'
        this.setState({ badEnter, errorText, colorIcon, passGood: false, good: false })
        return;
      }
      else this.setState({ passGood: true })
      obj = {
        Login: login,
        //Addres: address,
        FullName: name + ' ' + surname,
        Password: password,
        Role: 2
      }
      url = 'http://192.168.43.80:5000/api/auth/signup/';
      log = 'Регистрации'
    }
    else {
      if (!login || !password) {
        Alert.alert('Внимание', 'Не все поля заполнены!',
          [{ text: 'OK' }],
          { cancelable: false },
        );
        return;
      }
      obj = {
        Login: login,
        Password: password,
      }
      url = 'http://192.168.43.80:5000/api/auth/signin';
      log = 'Входа'
    }
    if (good) {
      this.setState({ submit: true })
      fetch(url, {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        headers: {
          'Accept': "application/json",
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(obj), //JSON.stringify(
      })
        .then(function (response) {
          $this.setClearState();
          if (response.status == 200 || response.status == 201) {
            console.log('Успех ' + log + ' Post статус: ' + response.status + ' ok: ' + response.ok);
            console.log(response);
            if (signup) {
              Alert.alert('Вы зарегистрированы!', 'Пожалуйста, войдите в систему используя свой логин и пароль',
                [{ text: 'OK' }]);
            }
            else {
              return response.json();
            }
          }
          if (response.status == 500) {
            console.log('Server Error', "Status: " + response.status + ' ' + response)
            Alert.alert('Внимание', 'Ошибка сервера!',
              [{ text: 'OK' }]);
          }
          if (response.status == 400) {
            console.log('Bad Request', "Status: " + response.status + ' ' + response)
            Alert.alert('Внимание', 'Логин или пароль не верны!',
              [{ text: 'OK' }]);
          }
        })
        .then(function (data: AuthData) {
          if (!signup) {
            console.log('data: ',data);
            actions.Login(data.token, data.userLogin)
            navigation.goBack();
          }
        })
        .catch(error => {
          console.log('Внимание', 'Ошибка ' + log + ' Post fetch: ' + error);
            //[{ text: 'OK' }]);
          $this.setClearState();
        });
    }
    else {
      Alert.alert('Внимание', 'Заполните поля правильно!',
        [{ text: 'OK' }],
        { cancelable: false },
      );
      return;
    }
  }
  private setClearState() {
    var arr: boolean[] = [];
    for (var i = 0; i <= 6; i++) {
      arr.push(false);
    }
    var arrText: string[] = [];
    for (var i = 0; i <= 6; i++) {
      arrText.push('');
    }
    var arrColor: string[] = [];
    for (var i = 0; i <= 6; i++) {
      arrColor.push('#000');
    }
    this.setState({
      login: '', address: '', name: '', surname: '',
      password: '', repeatPassword: '', color: '#000',
      signup: false, good: true, passGood: false, submit: false,
      badEnter: arr, errorText: arrText, colorIcon: arrColor,
    })
  }
}

const styles = StyleSheet.create({
  icon: {
    width: 35,
    height: 35,
    marginRight: 10,
    borderRadius: 18,
  },
  textInput: {
    width: w * 0.8,
  },
  input: {
    height: 40,
    borderColor: 'gray',
    borderWidth: 1,
    borderRadius: 10,
    padding: 10,
  },
  inputMultiline: {
    borderColor: 'gray',
    borderWidth: 1,
    borderRadius: 10,
    paddingHorizontal: 10,
    paddingVertical: 5,
    alignContent: 'flex-start',
  },
  flex: {
    margin: 120,
    textAlign: 'center',
    justifyContent: 'flex-end',
    paddingBottom: 200,
  },
  fixToText: {
    marginTop: 20,
    flexDirection: 'row',
    justifyContent: 'center',
  },
  button: {
    marginTop: 20,
    width: 250,
  },
  buttonContainer: {
    backgroundColor: '#92582D',
    height: 40,
    alignItems: 'center',
    justifyContent: 'center',
    borderRadius: 7,
  },
  buttonTitle: {
    fontSize: 18,
    color: '#fff',
  },
  link: {
    marginVertical: 20,
    color: '#92582D',
    textAlign: 'center',
    fontSize: 20,
  },
  error: {
    marginTop: 5,
    color: 'red',
    marginBottom: -10
  },
  indicator: {
    marginTop: 50,
    position: 'absolute',
    alignSelf: 'center',
  },
})

export { AuthScreen };