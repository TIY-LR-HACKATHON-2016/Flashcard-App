import angular from 'angular';
import config from './config';
import controller from './controller';

let subject = angular.module('set', []);

subject.config(config);
subject.controller('SetController', controller);

export default subject;
