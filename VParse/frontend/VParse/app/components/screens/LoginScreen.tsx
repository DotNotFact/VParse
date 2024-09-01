// app/components/screens/LoginScreen.tsx
import React from "react";
import { View, StyleSheet, Button } from "react-native";
import { useNavigation } from "@react-navigation/native";
import { NativeStackNavigationProp } from "@react-navigation/native-stack";
import { useVKAuth } from "@/services/Auth/AuthService";

type RootStackParamList = {
  Login: undefined;
  Home: undefined;
};

type LoginScreenNavigationProp = NativeStackNavigationProp<
  RootStackParamList,
  "Login"
>;

const LoginScreen: React.FC = () => {
  const navigation = useNavigation<LoginScreenNavigationProp>();
  const { handleVKLogin } = useVKAuth();

  const handleLogin = async () => {
    const success = await handleVKLogin();
    if (success) {
      navigation.navigate("Home");
    }
  };

  return (
    <View style={styles.container}>
      <Button onPress={handleLogin} title="Login with VK" />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
  },
});

export default LoginScreen;
