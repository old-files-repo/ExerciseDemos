import React, { Component } from 'react';

export class Exam extends Component {
  static displayName = Exam.name;

  constructor (props) {
    super(props);
    this.state = { forecasts: [], loading: true };
    this.renderForecastsTable = this.renderForecastsTable.bind(this);

    this.fetchAll();
  }

  fetchAll=()=>{
    fetch('api/SampleData')
    .then(response => response.json())
    .then(data => {
      this.setState({ forecasts: data, loading: false });
    });
  }

  handleExam(id,level) {
    let headers = new Headers();
    let options = {};
    headers.append( "Content-Type", "application/json; charset=utf-8");
    options.headers = headers;
    options.method = "PUT";
    options.credentials = "include";
    options.mode = "cors";
    fetch('/api/SampleData/exam/'+id+'/'+level,options)
    .then(data => {
      this.fetchAll();
    });
  }

  // handleExam(id) {
  //   let headers = new Headers();
  //   let options = {};
  //   headers.append( "Content-Type", "application/json; charset=utf-8");
  //   options.headers = headers;
  //   options.method = "PUT";
  //   options.credentials = "include";
  //   options.mode = "cors";
  //   fetch('/api/SampleData/exam/'+id,options)
  //   .then(data => {
  //     this.fetchAll();
  //   });
  // }

  handleReject =id=>  {
    let headers = new Headers();
    let options = {};
    headers.append( "Content-Type", "application/json; charset=utf-8");
    options.headers = headers;
    options.method = "PUT";
    options.credentials = "include";
    options.mode = "cors";
    fetch('/api/SampleData/reject/'+id,options)
    .then(data => {
      this.fetchAll();
    });
  }

  renderForecastsTable =(forecasts) => {
    ///const that
    return (
      <table className='table table-striped'>
         <thead>
          <tr>
            <th>Id</th>
            <th>时间</th>
            <th>申请人</th>
            <th>申请内容</th>
            <th>审批状态</th>
            <th>操作</th>
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
              <td>
                <a href="javascript:void(0)" onClick={()=>this.handleExam(forecast.id,1)}>一级审批</a><br/>
                <a href="javascript:void(0)" onClick={()=>this.handleExam(forecast.id,2)}>二级审批</a><br/>
                <a href="javascript:void(0)" onClick={()=>this.handleExam(forecast.id,3)}>三级审批</a><br/>
                <a href="javascript:void(0)" onClick={()=>this.handleReject(forecast.id)}>驳回</a>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    );
  };

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1>审批页面</h1>
        {contents}
      </div>
    );
  }
}
