using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Opensea.Contracts.ERC721Full.ContractDefinition
{


  public partial class ERC721FullDeployment : ERC721FullDeploymentBase
  {
    public ERC721FullDeployment() : base(BYTECODE) { }
    public ERC721FullDeployment(string byteCode) : base(byteCode) { }
  }

  public class ERC721FullDeploymentBase : ContractDeploymentMessage
  {
    public static string BYTECODE = "60806040523480156200001157600080fd5b50604051620011ab380380620011ab833981018060405260408110156200003757600080fd5b8101908080516401000000008111156200005057600080fd5b820160208101848111156200006457600080fd5b81516401000000008111828201871017156200007f57600080fd5b505092919060200180516401000000008111156200009c57600080fd5b82016020810184811115620000b057600080fd5b8151640100000000811182820187101715620000cb57600080fd5b509093508492508391506200010b90507f01ffc9a700000000000000000000000000000000000000000000000000000000640100000000620001dd810204565b6200013f7f80ac58cd00000000000000000000000000000000000000000000000000000000640100000000620001dd810204565b620001737f780e9d6300000000000000000000000000000000000000000000000000000000640100000000620001dd810204565b8151620001889060099060208501906200024a565b5080516200019e90600a9060208401906200024a565b50620001d37f5b5e139f00000000000000000000000000000000000000000000000000000000640100000000620001dd810204565b50505050620002ef565b7fffffffff0000000000000000000000000000000000000000000000000000000080821614156200020d57600080fd5b7fffffffff00000000000000000000000000000000000000000000000000000000166000908152602081905260409020805460ff19166001179055565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106200028d57805160ff1916838001178555620002bd565b82800160010185558215620002bd579182015b82811115620002bd578251825591602001919060010190620002a0565b50620002cb929150620002cf565b5090565b620002ec91905b80821115620002cb5760008155600101620002d6565b90565b610eac80620002ff6000396000f3fe608060405234801561001057600080fd5b506004361061011d576000357c0100000000000000000000000000000000000000000000000000000000900480634f6ccce7116100b4578063a22cb46511610083578063a22cb46514610370578063b88d4fde1461039e578063c87b56dd14610464578063e985e9c5146104815761011d565b80634f6ccce7146103085780636352211e1461032557806370a082311461034257806395d89b41146103685761011d565b806318160ddd116100f057806318160ddd1461025657806323b872dd146102705780632f745c59146102a657806342842e0e146102d25761011d565b806301ffc9a71461012257806306fdde0314610172578063081812fc146101ef578063095ea7b314610228575b600080fd5b61015e6004803603602081101561013857600080fd5b50357bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19166104af565b604080519115158252519081900360200190f35b61017a6104e3565b6040805160208082528351818301528351919283929083019185019080838360005b838110156101b457818101518382015260200161019c565b50505050905090810190601f1680156101e15780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b61020c6004803603602081101561020557600080fd5b503561057a565b60408051600160a060020a039092168252519081900360200190f35b6102546004803603604081101561023e57600080fd5b50600160a060020a0381351690602001356105ac565b005b61025e610662565b60408051918252519081900360200190f35b6102546004803603606081101561028657600080fd5b50600160a060020a03813581169160208101359091169060400135610668565b61025e600480360360408110156102bc57600080fd5b50600160a060020a03813516906020013561068d565b610254600480360360608110156102e857600080fd5b50600160a060020a038135811691602081013590911690604001356106da565b61025e6004803603602081101561031e57600080fd5b50356106f6565b61020c6004803603602081101561033b57600080fd5b503561072b565b61025e6004803603602081101561035857600080fd5b5035600160a060020a0316610755565b61017a61078d565b6102546004803603604081101561038657600080fd5b50600160a060020a03813516906020013515156107ee565b610254600480360360808110156103b457600080fd5b600160a060020a038235811692602081013590911691604082013591908101906080810160608201356401000000008111156103ef57600080fd5b82018360208201111561040157600080fd5b8035906020019184600183028401116401000000008311171561042357600080fd5b91908080601f016020809104026020016040519081016040528093929190818152602001838380828437600092019190915250929550610872945050505050565b61017a6004803603602081101561047a57600080fd5b503561089a565b61015e6004803603604081101561049757600080fd5b50600160a060020a038135811691602001351661094f565b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff191660009081526020819052604090205460ff1690565b60098054604080516020601f600260001961010060018816150201909516949094049384018190048102820181019092528281526060939092909183018282801561056f5780601f106105445761010080835404028352916020019161056f565b820191906000526020600020905b81548152906001019060200180831161055257829003601f168201915b505050505090505b90565b60006105858261097d565b151561059057600080fd5b50600090815260026020526040902054600160a060020a031690565b60006105b78261072b565b9050600160a060020a0383811690821614156105d257600080fd5b33600160a060020a03821614806105ee57506105ee813361094f565b15156105f957600080fd5b600082815260026020526040808220805473ffffffffffffffffffffffffffffffffffffffff1916600160a060020a0387811691821790925591518593918516917f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92591a4505050565b60075490565b610672338261099a565b151561067d57600080fd5b6106888383836109f9565b505050565b600061069883610755565b82106106a357600080fd5b600160a060020a03831660009081526005602052604090208054839081106106c757fe5b9060005260206000200154905092915050565b6106888383836020604051908101604052806000815250610872565b6000610700610662565b821061070b57600080fd5b600780548390811061071957fe5b90600052602060002001549050919050565b600081815260016020526040812054600160a060020a031680151561074f57600080fd5b92915050565b6000600160a060020a038216151561076c57600080fd5b600160a060020a038216600090815260036020526040902061074f90610a18565b600a8054604080516020601f600260001961010060018816150201909516949094049384018190048102820181019092528281526060939092909183018282801561056f5780601f106105445761010080835404028352916020019161056f565b600160a060020a03821633141561080457600080fd5b336000818152600460209081526040808320600160a060020a03871680855290835292819020805460ff1916861515908117909155815190815290519293927f17307eab39ab6107e8899845ad3d59bd9653f200f220920489ca2b5937696c31929181900390910190a35050565b61087d848484610668565b61088984848484610a1c565b151561089457600080fd5b50505050565b60606108a58261097d565b15156108b057600080fd5b6000828152600b602090815260409182902080548351601f6002600019610100600186161502019093169290920491820184900484028101840190945280845290918301828280156109435780601f1061091857610100808354040283529160200191610943565b820191906000526020600020905b81548152906001019060200180831161092657829003601f168201915b50505050509050919050565b600160a060020a03918216600090815260046020908152604080832093909416825291909152205460ff1690565b600090815260016020526040902054600160a060020a0316151590565b6000806109a68361072b565b905080600160a060020a031684600160a060020a031614806109e1575083600160a060020a03166109d68461057a565b600160a060020a0316145b806109f157506109f1818561094f565b949350505050565b610a04838383610b98565b610a0e8382610c87565b6106888282610d7e565b5490565b6000610a3084600160a060020a0316610dbc565b1515610a3e575060016109f1565b6040517f150b7a020000000000000000000000000000000000000000000000000000000081523360048201818152600160a060020a03888116602485015260448401879052608060648501908152865160848601528651600095928a169463150b7a029490938c938b938b939260a4019060208501908083838e5b83811015610ad1578181015183820152602001610ab9565b50505050905090810190601f168015610afe5780820380516001836020036101000a031916815260200191505b5095505050505050602060405180830381600087803b158015610b2057600080fd5b505af1158015610b34573d6000803e3d6000fd5b505050506040513d6020811015610b4a57600080fd5b50517bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19167f150b7a020000000000000000000000000000000000000000000000000000000014915050949350505050565b82600160a060020a0316610bab8261072b565b600160a060020a031614610bbe57600080fd5b600160a060020a0382161515610bd357600080fd5b610bdc81610dc4565b600160a060020a0383166000908152600360205260409020610bfd90610e0e565b600160a060020a0382166000908152600360205260409020610c1e90610e25565b600081815260016020526040808220805473ffffffffffffffffffffffffffffffffffffffff1916600160a060020a0386811691821790925591518493918716917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef91a4505050565b600160a060020a038216600090815260056020526040812054610cb190600163ffffffff610e2e16565b600083815260066020526040902054909150808214610d4e57600160a060020a0384166000908152600560205260408120805484908110610cee57fe5b90600052602060002001549050806005600087600160a060020a0316600160a060020a0316815260200190815260200160002083815481101515610d2e57fe5b600091825260208083209091019290925591825260069052604090208190555b600160a060020a0384166000908152600560205260409020805490610d77906000198301610e43565b5050505050565b600160a060020a0390911660009081526005602081815260408084208054868652600684529185208290559282526001810183559183529091200155565b6000903b1190565b600081815260026020526040902054600160a060020a031615610e0b576000818152600260205260409020805473ffffffffffffffffffffffffffffffffffffffff191690555b50565b8054610e2190600163ffffffff610e2e16565b9055565b80546001019055565b600082821115610e3d57600080fd5b50900390565b8154818355818111156106885760008381526020902061068891810190830161057791905b80821115610e7c5760008155600101610e68565b509056fea165627a7a72305820dc61acc103cc3cf7e43a7057b1b26cf9ba8475d63002a899590b6e9f1df34a4b0029";
    public ERC721FullDeploymentBase() : base(BYTECODE) { }
    public ERC721FullDeploymentBase(string byteCode) : base(byteCode) { }
    [Parameter("string", "name", 1)]
    public virtual string Name { get; set; }
    [Parameter("string", "symbol", 2)]
    public virtual string Symbol { get; set; }
  }

  public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

  [Function("supportsInterface", "bool")]
  public class SupportsInterfaceFunctionBase : FunctionMessage
  {
    [Parameter("bytes4", "interfaceId", 1)]
    public virtual byte[] InterfaceId { get; set; }
  }

  public partial class NameFunction : NameFunctionBase { }

  [Function("name", "string")]
  public class NameFunctionBase : FunctionMessage
  {

  }

  public partial class GetApprovedFunction : GetApprovedFunctionBase { }

  [Function("getApproved", "address")]
  public class GetApprovedFunctionBase : FunctionMessage
  {
    [Parameter("uint256", "tokenId", 1)]
    public virtual BigInteger TokenId { get; set; }
  }

  public partial class ApproveFunction : ApproveFunctionBase { }

  [Function("approve")]
  public class ApproveFunctionBase : FunctionMessage
  {
    [Parameter("address", "to", 1)]
    public virtual string To { get; set; }
    [Parameter("uint256", "tokenId", 2)]
    public virtual BigInteger TokenId { get; set; }
  }

  public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

  [Function("totalSupply", "uint256")]
  public class TotalSupplyFunctionBase : FunctionMessage
  {

  }

  public partial class TransferFromFunction : TransferFromFunctionBase { }

  [Function("transferFrom")]
  public class TransferFromFunctionBase : FunctionMessage
  {
    [Parameter("address", "from", 1)]
    public virtual string From { get; set; }
    [Parameter("address", "to", 2)]
    public virtual string To { get; set; }
    [Parameter("uint256", "tokenId", 3)]
    public virtual BigInteger TokenId { get; set; }
  }

  public partial class TokenOfOwnerByIndexFunction : TokenOfOwnerByIndexFunctionBase { }

  [Function("tokenOfOwnerByIndex", "uint256")]
  public class TokenOfOwnerByIndexFunctionBase : FunctionMessage
  {
    [Parameter("address", "owner", 1)]
    public virtual string Owner { get; set; }
    [Parameter("uint256", "index", 2)]
    public virtual BigInteger Index { get; set; }
  }

  public partial class TokenByIndexFunction : TokenByIndexFunctionBase { }

  [Function("tokenByIndex", "uint256")]
  public class TokenByIndexFunctionBase : FunctionMessage
  {
    [Parameter("uint256", "index", 1)]
    public virtual BigInteger Index { get; set; }
  }

  public partial class OwnerOfFunction : OwnerOfFunctionBase { }

  [Function("ownerOf", "address")]
  public class OwnerOfFunctionBase : FunctionMessage
  {
    [Parameter("uint256", "tokenId", 1)]
    public virtual BigInteger TokenId { get; set; }
  }

  public partial class BalanceOfFunction : BalanceOfFunctionBase { }

  [Function("balanceOf", "uint256")]
  public class BalanceOfFunctionBase : FunctionMessage
  {
    [Parameter("address", "owner", 1)]
    public virtual string Owner { get; set; }
  }

  public partial class SymbolFunction : SymbolFunctionBase { }

  [Function("symbol", "string")]
  public class SymbolFunctionBase : FunctionMessage
  {

  }

  public partial class SetApprovalForAllFunction : SetApprovalForAllFunctionBase { }

  [Function("setApprovalForAll")]
  public class SetApprovalForAllFunctionBase : FunctionMessage
  {
    [Parameter("address", "to", 1)]
    public virtual string To { get; set; }
    [Parameter("bool", "approved", 2)]
    public virtual bool Approved { get; set; }
  }

  public partial class SafeTransferFromFunction : SafeTransferFromFunctionBase { }

  [Function("safeTransferFrom")]
  public class SafeTransferFromFunctionBase : FunctionMessage
  {
    [Parameter("address", "from", 1)]
    public virtual string From { get; set; }
    [Parameter("address", "to", 2)]
    public virtual string To { get; set; }
    [Parameter("uint256", "tokenId", 3)]
    public virtual BigInteger TokenId { get; set; }
    [Parameter("bytes", "_data", 4)]
    public virtual byte[] Data { get; set; }
  }

  public partial class TokenURIFunction : TokenURIFunctionBase { }

  [Function("tokenURI", "string")]
  public class TokenURIFunctionBase : FunctionMessage
  {
    [Parameter("uint256", "tokenId", 1)]
    public virtual BigInteger TokenId { get; set; }
  }

  public partial class IsApprovedForAllFunction : IsApprovedForAllFunctionBase { }

  [Function("isApprovedForAll", "bool")]
  public class IsApprovedForAllFunctionBase : FunctionMessage
  {
    [Parameter("address", "owner", 1)]
    public virtual string Owner { get; set; }
    [Parameter("address", "operator", 2)]
    public virtual string Operator { get; set; }
  }

  public partial class TransferEventDTO : TransferEventDTOBase { }

  [Event("Transfer")]
  public class TransferEventDTOBase : IEventDTO
  {
    [Parameter("address", "from", 1, true)]
    public virtual string From { get; set; }
    [Parameter("address", "to", 2, true)]
    public virtual string To { get; set; }
    [Parameter("uint256", "tokenId", 3, true)]
    public virtual BigInteger TokenId { get; set; }
  }

  public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

  [Event("Approval")]
  public class ApprovalEventDTOBase : IEventDTO
  {
    [Parameter("address", "owner", 1, true)]
    public virtual string Owner { get; set; }
    [Parameter("address", "approved", 2, true)]
    public virtual string Approved { get; set; }
    [Parameter("uint256", "tokenId", 3, true)]
    public virtual BigInteger TokenId { get; set; }
  }

  public partial class ApprovalForAllEventDTO : ApprovalForAllEventDTOBase { }

  [Event("ApprovalForAll")]
  public class ApprovalForAllEventDTOBase : IEventDTO
  {
    [Parameter("address", "owner", 1, true)]
    public virtual string Owner { get; set; }
    [Parameter("address", "operator", 2, true)]
    public virtual string Operator { get; set; }
    [Parameter("bool", "approved", 3, false)]
    public virtual bool Approved { get; set; }
  }

  public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

  [FunctionOutput]
  public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO
  {
    [Parameter("bool", "", 1)]
    public virtual bool ReturnValue1 { get; set; }
  }

  public partial class NameOutputDTO : NameOutputDTOBase { }

  [FunctionOutput]
  public class NameOutputDTOBase : IFunctionOutputDTO
  {
    [Parameter("string", "", 1)]
    public virtual string ReturnValue1 { get; set; }
  }

  public partial class GetApprovedOutputDTO : GetApprovedOutputDTOBase { }

  [FunctionOutput]
  public class GetApprovedOutputDTOBase : IFunctionOutputDTO
  {
    [Parameter("address", "", 1)]
    public virtual string ReturnValue1 { get; set; }
  }



  public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

  [FunctionOutput]
  public class TotalSupplyOutputDTOBase : IFunctionOutputDTO
  {
    [Parameter("uint256", "", 1)]
    public virtual BigInteger ReturnValue1 { get; set; }
  }



  public partial class TokenOfOwnerByIndexOutputDTO : TokenOfOwnerByIndexOutputDTOBase { }

  [FunctionOutput]
  public class TokenOfOwnerByIndexOutputDTOBase : IFunctionOutputDTO
  {
    [Parameter("uint256", "", 1)]
    public virtual BigInteger ReturnValue1 { get; set; }
  }



  public partial class TokenByIndexOutputDTO : TokenByIndexOutputDTOBase { }

  [FunctionOutput]
  public class TokenByIndexOutputDTOBase : IFunctionOutputDTO
  {
    [Parameter("uint256", "", 1)]
    public virtual BigInteger ReturnValue1 { get; set; }
  }

  public partial class OwnerOfOutputDTO : OwnerOfOutputDTOBase { }

  [FunctionOutput]
  public class OwnerOfOutputDTOBase : IFunctionOutputDTO
  {
    [Parameter("address", "", 1)]
    public virtual string ReturnValue1 { get; set; }
  }

  public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

  [FunctionOutput]
  public class BalanceOfOutputDTOBase : IFunctionOutputDTO
  {
    [Parameter("uint256", "", 1)]
    public virtual BigInteger ReturnValue1 { get; set; }
  }

  public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

  [FunctionOutput]
  public class SymbolOutputDTOBase : IFunctionOutputDTO
  {
    [Parameter("string", "", 1)]
    public virtual string ReturnValue1 { get; set; }
  }





  public partial class TokenURIOutputDTO : TokenURIOutputDTOBase { }

  [FunctionOutput]
  public class TokenURIOutputDTOBase : IFunctionOutputDTO
  {
    [Parameter("string", "", 1)]
    public virtual string ReturnValue1 { get; set; }
  }

  public partial class IsApprovedForAllOutputDTO : IsApprovedForAllOutputDTOBase { }

  [FunctionOutput]
  public class IsApprovedForAllOutputDTOBase : IFunctionOutputDTO
  {
    [Parameter("bool", "", 1)]
    public virtual bool ReturnValue1 { get; set; }
  }
}
