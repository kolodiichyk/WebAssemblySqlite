export function initIndexedDB(dbName, storeName, versionStoreName) {
    return new Promise((resolve, reject) => {
        const request = indexedDB.open(dbName, 1);

        console.log("JS BLAZOR: initIndexedDB");

        request.onerror = () => reject(request.error);
        request.onsuccess = () => resolve();

        request.onupgradeneeded = (event) => {
            const db = event.target.result;

            console.log("JS BLAZOR initIndexedDB: onupgradeneeded");

            if (!db.objectStoreNames.contains(storeName)) {
                console.log("JS BLAZOR initIndexedDB: " + storeName);
                db.createObjectStore(storeName);
            }
            if (!db.objectStoreNames.contains(versionStoreName)) {
                console.log("JS BLAZOR initIndexedDB: " + versionStoreName);
                db.createObjectStore(versionStoreName);
            }
        };
    });
}

export function storeData(dbName, storeName, versionStoreName, key, data, version) {
    return new Promise((resolve, reject) => {
        const request = indexedDB.open(dbName);

        request.onerror = () => reject(request.error);
        request.onsuccess = (event) => {
            const db = event.target.result;
            const transaction = db.transaction([storeName, versionStoreName], 'readwrite');

            const store = transaction.objectStore(storeName);
            const versionStore = transaction.objectStore(versionStoreName);

            store.put(data, key);
            versionStore.put(version, key);

            resolve();
        };
    });
}

export function getDataOnly(dbName, storeName, key) {
    return new Promise((resolve, reject) => {
        const request = indexedDB.open(dbName);

        request.onerror = () => reject(request.error);
        request.onsuccess = (event) => {
            const db = event.target.result;
            const transaction = db.transaction(storeName, 'readonly');
            const store = transaction.objectStore(storeName);
            const getRequest = store.get(key);

            getRequest.onsuccess = () => resolve(getRequest.result);
            getRequest.onerror = () => reject(getRequest.error);
        };
    });
}

export function getVersion(dbName, versionStoreName, key) {
    return new Promise((resolve, reject) => {
        const request = indexedDB.open(dbName);

        request.onerror = () => reject(request.error);
        request.onsuccess = (event) => {
            const db = event.target.result;
            const transaction = db.transaction(versionStoreName, 'readonly');
            const store = transaction.objectStore(versionStoreName);
            const getRequest = store.get(key);

            getRequest.onsuccess = () => resolve(getRequest.result);
            getRequest.onerror = () => reject(getRequest.error);
        };
    });
}

export function deleteData(dbName, storeName, versionStoreName, key) {
    return new Promise((resolve, reject) => {
        const request = indexedDB.open(dbName);

        request.onerror = () => reject(request.error);
        request.onsuccess = (event) => {
            const db = event.target.result;
            const transaction = db.transaction([storeName, versionStoreName], 'readwrite');

            const store = transaction.objectStore(storeName);
            const versionStore = transaction.objectStore(versionStoreName);

            store.delete(key);
            versionStore.delete(key);

            resolve();
        };
    });
}
