import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Exam } from './components/Exam';
import { Apply } from './components/Apply';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/apply' component={Apply} />
        <Route path='/exam' component={Exam} />
      </Layout>
    );
  }
}
