function requestValidator(request) {

    const methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const uriPattern = /^([\w\.]+|\*)$/g;
    const versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const msPattern = /^[^<>\\&'"]*$/g;

    if (!methods.includes(request.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }
    if (!request.uri || !uriPattern.test(request.uri)) {
        throw new Error('Invalid request header: Invalid URI');
    }
    if (!versions.includes(request.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }
    if (!request.hasOwnProperty('message') || !msPattern.test(request.message)) {
        throw new Error('Invalid request header: Invalid Message');
    }
    return request;

}

console.log(requestValidator({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}));