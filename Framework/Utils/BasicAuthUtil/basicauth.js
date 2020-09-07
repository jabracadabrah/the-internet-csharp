chrome.webRequest.onAuthRequired.addListener(
function handler(details){
 return {'authCredentials': {username: "admin", password: "admin"}};
},
{urls:["<all_urls>"]},
['blocking']);