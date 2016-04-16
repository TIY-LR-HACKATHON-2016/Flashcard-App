import angular from 'angular';
import config from './config';
import controller from './controller';

let subject = angular.module('subject', []);

subject.config(config);
subject.controller('SubjectController', controller);

export default subject;
