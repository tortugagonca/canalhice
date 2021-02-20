import React from 'react';
import ReactDOM from 'react-dom';
import App from './components/App';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const root = document.getElementById('root');
ReactDOM.render(<App />, root);
