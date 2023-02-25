import {sendMessage} from "./ipc.js";

export async function getData(callback) {
    sendMessage("getData", null, callback);
}