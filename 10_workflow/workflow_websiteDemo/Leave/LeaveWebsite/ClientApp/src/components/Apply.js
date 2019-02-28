import React, { Component } from 'react';

export class Apply extends Component {
  constructor (props) {
    super(props);
    this.state = {
       applyUser: "",
       applyContent: ""
      };
    this.save = this.save.bind(this);
    this.handleChangeUser = this.handleChangeUser.bind(this);
    this.handleChangeContent = this.handleChangeContent.bind(this);
  }

  save () {
    let headers = new Headers();
    let options = {};
    headers.append( "Content-Type", "application/json; charset=utf-8");
    options.headers = headers;
    options.body = JSON.stringify(this.state);
    options.method = "POST";
    options.credentials = "include";
    options.mode = "cors";
    fetch('/api/SampleData',options)
    .then(data => {
      this.setState({   
        applyUser: null,
        applyContent: null });
    });
  }

  handleChangeUser(event) {
    this.setState({applyUser: event.target.value});
  }

  handleChangeContent(event) {
    this.setState({applyContent: event.target.value});
  }

  render () {
    const values = {...this.state};
    return (
      <div>
        <div>
          <p>申请人</p>
          <input type="text" value={values.applyUser} onChange={this.handleChangeUser}></input>
        </div>
        <div>
          <p>内容</p>
          <input type="text" value={values.applyContent} onChange={this.handleChangeContent}></input>
        </div>
        <div>
          <button className="btn btn-primary" onClick={this.save}>确定</button>
        </div>
      </div>
    );
  }
}
