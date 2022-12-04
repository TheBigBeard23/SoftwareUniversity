export function getUserData() {
    const data = JSON.parse(localStorage.getItem('userData'));
    return data;
}
export function setUserData(data) {
    localStorage.setItem('userData', JSON.stringify(data));
}
export function clearUserData() {
    localStorage.removeItem('userData');
}