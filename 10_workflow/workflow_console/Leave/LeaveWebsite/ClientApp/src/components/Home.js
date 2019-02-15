import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  constructor (props) {
    super(props);
    this.state = { forecasts: [], loading: true };

    fetch('api/SampleData')
      .then(response => response.json())
      .then(data => {
        this.setState({ forecasts: data, loading: false });
      });
  }

  static renderForecastsTable (forecasts) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Id</th>
            <th>时间</th>
            <th>申请人</th>
            <th>申请内容</th>
            <th>审批状态</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.id}>
              <td>{forecast.id}</td>
              <td>{forecast.createDate}</td>
              <td>{forecast.applyUser}</td>
              <td>{forecast.applyContent}</td>
              <td>{forecast.examState}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>加载中...</em></p>
      : Home.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1>请假记录</h1>
        {contents}
      </div>
    );
  }
}
