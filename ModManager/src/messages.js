/*
    Facilitates communication between the main C# program and the React app.  
    Specific to CefSharp.
*/

/**
 * Sends a message to the C# program.  
 * `JavaScript -> C#`
 * @param {string} message
 * @param {object} data
 * @param {Function} callback
 */
export function sendMessage(message, data = {}, callback = null) {
    CefSharp.PostMessage({
        "message": message,
        "data": data,
        "callback": callback
    });
}

/**
 * Register an event handler that gets called, when the C# program sends a message to the React app.  
 * `C# -> JavaScript`
 * @param {Function} callback - Function(message: string, data: any)
 */
export function registerMessageHandler(callback) {
    document.addEventListener("cefsharpmessagerecv", (event) => {
        if (event.detail != null)
            callback(event.detail.message, event.detail.data);
        else
            callback(null, null);
    });
}