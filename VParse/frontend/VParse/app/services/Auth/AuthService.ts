import { makeRedirectUri, useAuthRequest } from "expo-auth-session";
import * as WebBrowser from "expo-web-browser";
import AsyncStorage from "@react-native-async-storage/async-storage";
import {
  VK_CLIENT_ID,
  VK_REDIRECT_URI,
  VK_SCOPE,
  VK_API_VERSION,
  API_URL,
} from "@env";

WebBrowser.maybeCompleteAuthSession();

export const useVKAuth = () => {
  const [request, response, promptAsync] = useAuthRequest(
    {
      clientId: VK_CLIENT_ID,
      scopes: [VK_SCOPE],
      redirectUri: makeRedirectUri({
        native: VK_REDIRECT_URI,
      }),
    },
    {
      authorizationEndpoint: "https://oauth.vk.com/authorize",
      tokenEndpoint: "https://oauth.vk.com/access_token",
      revocationEndpoint: "https://oauth.vk.com/revoke",
    }
  );

  const handleVKLogin = async () => {
    try {
      const result = await promptAsync();
      if (result?.type === "success") {
        const { code } = result.params;
        const response = await fetch(
          `${API_URL}/api/auth/vk-callback?code=${code}`
        );
        const data = await response.json();
        await AsyncStorage.setItem("userToken", data.token);
        return true;
      }
    } catch (error) {
      console.error("Error during login:", error);
    }
    return false;
  };

  return {
    request,
    response,
    handleVKLogin,
  };
};

export const logout = async () => {
  await AsyncStorage.removeItem("userToken");
};

export const getToken = async () => {
  return await AsyncStorage.getItem("userToken");
};
