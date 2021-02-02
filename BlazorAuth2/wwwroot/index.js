window.addCookie = (cookie) => {
    document.cookie = cookie;
}

window.removeCookie = (name) => {
    document.cookie = name + '=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
}