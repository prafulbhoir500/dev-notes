#Config
```javascript
apiClient.interceptors.response.use(
    (response) => response,
    async (error) => {
        const originalRequest = error.config;

        console.log('Interceptor hit, error:', error); // Add log here to check error status
        console.log('Original Request:', originalRequest);

        // if 401 and not retrying already
        if (error.response?.status === 401 && !originalRequest._retry) {
            console.log('Received 401, trying to refresh token');

            if (isRefreshing) {
                console.log('Waiting for the refresh token to complete');
                return new Promise(function (resolve, reject) {
                    failedQueue.push({ resolve, reject });
                })
                    .then(() => {
                        console.log('Retrying original request after refresh');
                        return apiClient(originalRequest);
                    })
                    .catch((err) => {
                        console.log('Error during retrying original request', err);
                        return Promise.reject(err);
                    });
            }

            originalRequest._retry = true;
            isRefreshing = true;

            try {
                // Call refresh-token endpoint
                const refreshResponse = await apiClient.post("/auth/refresh-token");
                console.log('Refresh token response:', refreshResponse);

                processQueue(null);
                isRefreshing = false;

                // Retry the failed request
                return apiClient(originalRequest);
            } catch (err) {
                console.log('Error during refresh token', err);
                processQueue(err, null);
                isRefreshing = false;
                return Promise.reject(err);
            }
        }

        return Promise.reject(error);
    }
);


```