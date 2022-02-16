import axios from "axios";

export const LerConteudoDaImagem = async (formData) => {

    let resultado;

    await axios({
        method : "POST",
        url : "https://ocr-equipamentos-edson.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data : formData,
        headers:{
            "Content-Type" : "multpart/form-data",
            "Ocp-Apim-Subscription-Key" : "1e7e3eb336d543c093e28b3d819fa4b1"
        }
    })
    .then(response =>{
        // console.log(response)
        resultado = FiltarOBJ(response.data)
    })
    .catch(erro => console.log(erro))

    return resultado;
}

export const  FiltarOBJ =   (obj) => {
    

    let resultado;

    obj.regions.forEach(region => {
        region.lines.forEach(line => {
            line.words.forEach(word => {
                if(word.text[0] === "1" && word.text[1] === "2"){
                    resultado = word.text
                }
            });
        });
    });


    return resultado;
}