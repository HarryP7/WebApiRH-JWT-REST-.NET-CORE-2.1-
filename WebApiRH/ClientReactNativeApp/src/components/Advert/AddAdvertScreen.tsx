import React, { Component } from 'react';
import {
  StyleSheet, ScrollView, View, Text, TouchableOpacity, TouchableWithoutFeedback,
  TouchableNativeFeedback,
  Button, TextInput, Alert
} from 'react-native';
import {
  LearnMoreLinks, Colors, DebugInstructions, ReloadInstructions,
} from 'react-native/Libraries/NewAppScreen';
import { SvgXml } from 'react-native-svg';
import { save, add } from '../../allSvg'
import { Header } from '..';//, styles 
import { Dropdown } from 'react-native-material-dropdown';
import { h, w } from '../../constants'
import { Category } from '../../enum/Enums'
import { backArrow } from '../../allSvg'
import SafeAreaView from 'react-native-safe-area-view';
//import { createStyles, makeStyles, Theme } from '@material-ui/core/styles';
//import {Fab} from '@material-ui/core';
//import Save from '@material-ui/icons/Save';

interface Props { }
interface State { }

class AddAdvertScreen extends Component<any, State, Props> {
  state = {
    text: '', title: '', floors: '', porches: '',
    year: '', status: '', colorT: '#000', colorPass: '#000',
    good: false, signup: false

  }

  render() {
    console.log('Props AddAdvertScreen', this.props)
    const { signup, text, title, floors, porches, year, colorT,
      colorPass, good, status } = this.state
    const { navigation } = this.props
    const { container, fixToText, label, label2, label3, textInput, textInput2,
      iconButton, inputMultiline, button, buttonContainer, sectionTitle,
      advertContainer, addPosition } = styles
    let dataStatus = [{
      value: Category.Repairs,
    }, {
      value: Category.EngineeringWorks,
    }, {
      value: Category.Overhaul,
    }, {
      value: Category.EnergySaving,
    }, {
      value: Category.Owners,
    }, {
      value: Category.CommunityInfrastructure,
    }, {
      value: Category.Attention,
    },];
    return (<View>
      <Header title='Добавление объявления'
        leftIcon={backArrow}
        onPressLeft={() => {
          this.setClearState();
          navigation.goBack();
        }} />
      <ScrollView>
        <SafeAreaView>
          <View style={container}>
            <View style={fixToText}>
              <View style={textInput}>
                <View style={{ flexDirection: 'row' }}>
                  <Text style={label}> Заголовок объявления <Text style={{ color: 'red' }}>*</Text></Text>
                </View>
                <TextInput
                  style={inputMultiline}
                  onChangeText={this.onChangeTitle.bind(this)}
                  placeholder='Заголовок..'
                  multiline={true}
                  numberOfLines={1}
                  value={title}
                />
              </View>
            </View>
            <View style={fixToText}>
              <View style={textInput}>
                <View style={{ flexDirection: 'row' }}>
                  <Text style={label}> Текст объявления <Text style={{ color: 'red' }}>*</Text></Text>
                </View>
                <TextInput
                  style={inputMultiline}
                  onChangeText={this.onChangeText.bind(this)}
                  placeholder='Введите текст..'
                  multiline={true}
                  numberOfLines={5}
                  value={text}
                  textAlignVertical='top'
                />
              </View>
            </View>

            <View style={fixToText}>
              <View style={textInput2}>
                <View style={{ flexDirection: 'row' }}>
                  <Text style={label2}> Категория <Text style={{ color: 'red' }}>*</Text></Text>
                </View>
                <Dropdown
                  data={dataStatus}
                  onChangeText={this.onChangeStatus.bind(this)}
                  value={status}
                />
                {/* placeholder='Выберите статус..' */}
              </View>
            </View>
          </View>

          <View style={advertContainer}>
            <View style={fixToText}>
              <View style={textInput}>
                <View style={{ flexDirection: 'row' }}>
                  <Text style={label}> Вопрос <Text style={{ color: 'red' }}>*</Text></Text>
                </View>
                <TextInput
                  style={inputMultiline}
                  onChangeText={this.onChangeTitle.bind(this)}
                  placeholder='Введите вопрос..'
                  multiline={true}
                  numberOfLines={1}
                  value={title}
                />
              </View>
            </View>
            <View style={fixToText}>
              <View style={textInput}>
                <View style={{ flexDirection: 'row' }}>
                  <Text style={label3}> Вариант ответа <Text style={{ color: 'red' }}>*</Text></Text>
                </View>
                <TextInput
                  style={inputMultiline}
                  onChangeText={this.onChangeText.bind(this)}
                  placeholder='Введите текст..'
                  multiline={true}
                  numberOfLines={1}
                  value={text}
                />
              </View>
            </View>

            <View style={addPosition}>
              <TouchableOpacity onPress={this.onSubmit.bind(this)} >
                  <SvgXml
                    xml={add}
                    style={iconButton} fill='green' />
              </TouchableOpacity>
              <Text>   Добавить еще один вариант ответа</Text>
            </View>
          </View>

          <View style={{ alignItems: 'flex-end' }}>
            <View style={button}>
              <TouchableOpacity onPress={this.onSubmit.bind(this)} >
                <View style={buttonContainer}>
                  <SvgXml
                    xml={save}
                    style={iconButton} fill='#fff' />
                  <Text style={sectionTitle}>Сохранить</Text>
                </View>
              </TouchableOpacity>
            </View>
          </View>
        </SafeAreaView>
      </ScrollView>
    </View>

    );
  }

  private onPress() {
    this.setClearState();
    this.setState({ signup: !this.state.signup });
  }

  private onChangeTitle(title: string) {
    this.setState({ title });
  }
  private onChangeText(text: string) {
    this.setState({ text: text });
  }
  private onChangeStatus(status: string) {
    this.setState({ status: status });
  }


  private onSubmit() {
    //     e.preventDefault();
    const { text, title, floors, porches, year, good, status } = this.state
    const { navigation } = this.props
    var $this = this;
    var obj, url, log: string;
    //if (signup) {
    if (!text || !title || !floors ||
      !porches || !year || !status) {
      Alert.alert('Внимание', 'Не все поля заполнены!',
        [{ text: 'OK' }],
        { cancelable: false },
      );
      return;
    }

    // }
    //else 
    this.setState({ good: true })
    obj = {
      Admin: "0000e0000-t0t-00t0-t000-00000000000",
      Title: title,
      Text: text,
      Category: status == Category.Repairs ? 1 :
        status == Category.EngineeringWorks ? 2 :
          status == Category.Overhaul ? 3 :
            status == Category.EnergySaving ? 4 :
              status == Category.Owners ? 5 :
                status == Category.CommunityInfrastructure ? 6 : 7,
      LocalGroup: navigation.state.params[0].fk_LocalGroup
    }
    url = 'http://192.168.43.80:5000/api/adverts/create/';
    log = 'Добавить Обьявление'

    fetch(url, {
      method: 'POST', // *GET, POST, PUT, DELETE, etc.
      headers: {
        'Accept': "application/json",
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(obj), //JSON.stringify(
    })
      .then(function (response) {
        if (response.status == 200 || response.status == 201) {
          console.log('Успех ' + log + ' Post статус: ' + response.status + ' ok: ' + response.ok);
          console.log(response);
          // if (signup)
          //   $this.setClearState();
          // else
          navigation.goBack();
        }
        if (response.status == 500)
          console.log('Server Error', "Status: " + response.status + ' ' + response.json())
      })
      .then(function () {

      })
      .catch(error => {
        Alert.alert('Внимание', 'Ошибка ' + log + ' Post fetch: ' + error,
          [{ text: 'OK' }]);
      });
  }
  private setClearState() {
    this.setState({
      text: '', title: '', floors: '', porches: '',
      year: '', status: '', colorT: '#000', colorPass: '#000',
      good: false, signup: false
    })
  }
}

const styles = StyleSheet.create({
  container: {
    borderColor: 'gray',
    borderWidth: 1,
    borderRadius: 10,
    margin: 10,
    paddingVertical: 5
  },
  icon: {
    width: 35,
    height: 35,
    marginRight: 10,
    borderRadius: 18,
  },
  textInput: {
    width: w * 0.9,
  },
  textInput2: {
    width: w * 0.85,
  },
  input: {
    height: 40,
    borderBottomColor: 'gray',
    borderBottomWidth: 1,
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
    marginVertical: 10,
    flexDirection: 'row',
    justifyContent: 'center',
  },
  button: {
    marginVertical: 30,
    width: 160,
    marginRight: 20
  },
  label: {
    marginTop: -10,
    marginBottom: 5,
    fontSize: 18,
    fontWeight: 'bold',
  },
  label2: {
    marginBottom: -25,
    fontSize: 18,
    fontWeight: 'bold',
    marginLeft: -7
  },
  label3: {
    marginTop: -10,
    marginBottom: 5,
    fontSize: 16,
  },
  iconButton: {
    width: 20,
    height: 20,
    marginLeft: 20,
  },  
  buttonContainer: {
    backgroundColor: '#15a009',
    height: 40,
    flexDirection: 'row',
    alignItems: 'center',
    borderRadius: 7
  },
  sectionTitle: {
    fontSize: 18,
    paddingLeft: 10,
    color: '#fff',
  },
  advertContainer: {
    borderColor: 'gray',
    backgroundColor: '#FFD0AE',
    borderWidth: 1,
    borderRadius: 10,
    margin: 10,
    paddingVertical: 5
  },
  addPosition: {
    flexDirection: 'row',
    marginBottom: 20,
    marginRight: 20,  
    alignItems: 'center',
  },
})
export { AddAdvertScreen };