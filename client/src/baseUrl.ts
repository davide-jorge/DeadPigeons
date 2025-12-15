const isProduction = import.meta.env.PROD;

const prod ="https://server-patient-cherry-3997.fly.dev/";
const dev ="http://localhost:5173/";

export const finalUrl = isProduction ? prod : dev;