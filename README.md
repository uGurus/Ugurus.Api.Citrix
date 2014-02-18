Ugurus.Api.Citrix
=================

This is an API wrapper library for the Citrix REST API which supports products such as GoToMeeting, GoToWebinar. More information on these APIs can be found here: https://developer.citrixonline.com/

Confguration
============

In order to make api calls you will first need to create an application and obtain a "Consumer Key" and "Consumer Secrect" from here: https://developer.citrixonline.com/user/me/apps

Usage
=====

~~~~
//Create a configuration
var config = new CitrixApiConfiguration("username", "password", "[YourConsumerKeyGoesHere");

//Instantiate a webinar client
var webinarClient = config.GetWebinarClient();

//register an attendeed for a specific webinar
var response = webinarClient.CreateRegistrant("firstName", "lastName, "emailAddress", "[idOfWebinar]").Result;
~~~~