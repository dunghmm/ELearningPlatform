namespace ELearningPlatform.API.Models.CommonModels
{
    public class DefineResponse
    {
        #region Int data
        public enum EnumCodes
        {
            /// <summary>
            /// Success
            /// </summary>
            R_CMN_200_01,
            /// <summary>
            /// Invalid parameter
            /// </summary>
            R_CMN_400_01,
            /// <summary>
            /// Validity period expired
            /// </summary>
            R_CMN_401_01,
            /// <summary>
            /// Username or password incorrect
            /// </summary>
            R_CMN_401_02,
            /// <summary>
            /// You do not have access. Please contact the system administrator
            /// </summary>
            R_CMN_403_01,
            /// <summary>
            /// No data found
            /// </summary>
            R_CMN_404_01,
            /// <summary>
            /// You do not have permission to access this resource. Please contact the system administrator
            /// </summary>
            R_CMN_404_02,
            /// <summary>
            /// Data does not exist
            /// </summary>
            R_CMN_404_03,
            /// <summary>
            /// It has already been deleted.
            /// </summary>
            R_CMN_404_05,
            /// <summary>
            /// {field}: data cannot be empty
            /// </summary>
            R_CMN_422_06,
            /// <summary>
            /// {field}: data cannot be empty
            /// </summary>
            R_CMN_422_07,
            /// <summary>
            /// Server error. Please contact the system administrator
            /// </summary>
            R_CMN_500_01,
        }
        public static readonly List<ResponseItem> ResponseItems = new()
        {
            new ResponseItem{ Code = "R_CMN_200_01", Message = "Success"},
            new ResponseItem{ Code = "R_CMN_400_01", Message = "Invalid parameter"},
            new ResponseItem{ Code = "R_CMN_401_01", Message = "Validity period expired"},
            new ResponseItem{ Code = "R_CMN_401_02", Message = "Username or password incorrect"},
            new ResponseItem{ Code = "R_CMN_403_01", Message = "You do not have access. Please contact the system administrator"},
            new ResponseItem{ Code = "R_CMN_404_01", Message = "No data found"},
            new ResponseItem{ Code = "R_CMN_404_02", Message = "You do not have permission to access this resource. Please contact the system administrator"},
            new ResponseItem{ Code = "R_CMN_404_03", Message = "Data does not exist"},
            new ResponseItem{ Code = "R_CMN_404_05", Message = "It has already been deleted."},
            new ResponseItem{ Code = "R_CMN_422_06", Message = "{field}: data cannot be empty"},
            new ResponseItem{ Code = "R_CMN_422_07", Message = "{field}: data cannot be empty"},
            new ResponseItem{ Code = "R_CMN_500_01", Message = "Server error. Please contact the system administrator"},
        };
        #endregion
    }
}
